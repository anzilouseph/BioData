using BioDataJWT.Dto;
using BioDataJWT.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BioDataJWT.Controllers
{
    [Route("api/Authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _service;

        public AuthenticationController(IAuthenticationService service)
        {
            _service = service;
        }


        //for Login (generate token is the thing hapening when we login)
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            try
            {
                var apiresponse = await _service.Login(login);
                return Ok(apiresponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {message = ex.Message});
            }
           
        }
    }
}
