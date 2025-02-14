using System.IdentityModel.Tokens.Jwt;
using BioDataJWT.Dto;
using BioDataJWT.IService;
using BioDataJWT.Utilitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BioDataJWT.Controllers
{
    [Route("api/AdminManagement")]
    [ApiController]
    public class AdminManagementController : ControllerBase
    {
        private readonly IAdminManagementService _service;

        public AdminManagementController(IAdminManagementService service)
        {
            _service = service;
        }



        //for getById
        [Authorize]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid users_id)
        {
            try
            {
                var userIdClaim = HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sid);
                if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out Guid claimedId))
                {
                    return Unauthorized(APIResponse<UserToListDto>.Error("UnAuthorized"));
                }

                var checkAdimOrNot = await _service.GetByID(claimedId); //here we are checking the role is admin of the Id we get from the token
                if (checkAdimOrNot.data.roleOfUser != "Admin")
                {
                    return Unauthorized(APIResponse<UserToListDto>.Error("Only Admin can Access This"));
                }

                var apiResponse = await _service.GetByID(users_id);

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {message = ex.Message});
            }
           
        }


        //for GetAll Users (this can be only get by the Admin so we give authorize)
        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult>GetAll()
        {
            try
            {
                var userIdClaim = HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sid);
                if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out Guid id))
                {
                    return Unauthorized(APIResponse<IEnumerable<UserToListDto>>.Error("UnAuthorized"));
                }
                var userRoleCheck = await _service.GetByID(id);
                if (userRoleCheck.data.roleOfUser != "Admin")
                {
                    return Ok(APIResponse<IEnumerable<UserToListDto>>.Error("Only Admin Can Access this"));
                }
                var apiResponse = await _service.GetAll();
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }
    }
}
