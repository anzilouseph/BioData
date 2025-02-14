using BioDataJWT.Dto;
using BioDataJWT.IRepo;
using BioDataJWT.IService;
using BioDataJWT.Utilitys;

namespace BioDataJWT.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepo _repo;
        private IConfiguration _config;

        public AuthenticationService(IAuthenticationRepo repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        //for login
        public async Task<APIResponse<string>> Login(LoginDto login)
        {
            var result = await _repo.Login(login);

            if(result == null)
            {
                return APIResponse<string>.Error("Invalid Email id");
            }

            var verifyPassord = forPasswordHasing.VerifyPassword(login.passwordOfUser, result.Password, result.salt);

            if(!verifyPassord)
            {
                return APIResponse<string>.Error("Password is wrong");
            }

            var masked = new UserToListDto
            {
                idOfUser = result.ID,
                nameOfUser = result.FullName,
                ageOfUser = result.Age,
                addressOfUser = result.Address,
                emailOfUser = result.Email,
            };

            var tokenGenerate = new GenerateJWT(_config);
            var accessToken = tokenGenerate.GenerateToken(masked);

            if(accessToken == null || string.IsNullOrEmpty(accessToken))
            {
                return APIResponse<string>.Error("Failed to generate Token");
            }
            return APIResponse<string>.Success(accessToken, "success");
            
        }

    }
}
