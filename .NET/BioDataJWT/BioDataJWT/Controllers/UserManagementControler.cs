using System.IdentityModel.Tokens.Jwt;
using BioDataJWT.Dto;
using BioDataJWT.IService;
using BioDataJWT.Utilitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BioDataJWT.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserManagementControler : ControllerBase
    {
        private readonly IUserManagementService _service;  //injecting the IthService so that we can call the method of it from here
        public UserManagementControler(IUserManagementService service)
        {
            _service = service;
        }


        //for AddUser
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(UserForCreationDto user)
        {
            try
            {
                var apiResponse = await _service.AddUser(user);
                return Ok(apiResponse);  //here we always send Ok(200) so that we can follow same pattern in every API and in the angular session we will check if the status is true or False
            }
            catch (Exception ex)
            {
                return StatusCode(500,new{message=ex.Message});
            }
        }



        //for get the profile of himself by the id(but here we are not giving any argument cuz login cheyyumbo oru token generate avum, aa token il ninn nammal id edukkum, pinne ath admin aano enn onnum check cheyyanda aavashym ella, cuz eppo login cheytha user swontham profile aanu kaanan sremikkunnath, so evde id argument aayi kodukkendaa token il ninn eduthoolum, marich eth oru admin aarnel admin nu ayalk aavashym olla oru user inte id type cheyth aalde profile edukkanam in such cases nammalk parameters aayit eeth user inte profile aano kittandee ayaldde id pass cheyyanam, evde athinte aavshym ella)
        [HttpGet("getOwnProfile")]        
        public async Task<IActionResult> getOwnData()
        {
            try
            {
                var userIdClaim = HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sid);
                if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out Guid user_id)) // evde login cheyyombo kittana token il ninn login cheytha current user inte Id eduthitt user_id enna variable ilekk store aakunnu
                {
                    return Unauthorized(APIResponse<UserToListDto>.Error("UnAuthorized"));
                }

                var apiResponse = await _service.getOwnData(user_id);
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        //for update their own data
        [Authorize]
        [HttpPut("UpdateOwnProfile")]
        public async Task<IActionResult> UpdateOwnData(UserForUpdationDto user)
        {
            try
            {
                var userIdClaim = HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sid);
                if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out Guid user_id))
                {
                    return Unauthorized(APIResponse<bool>.Error("Unable to generate token"));
                }
                var apiResponse = await _service.UpdateOwnData(user, user_id);
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


    }
}
