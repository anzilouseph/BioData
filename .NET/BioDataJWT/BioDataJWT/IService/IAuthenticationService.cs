using BioDataJWT.Dto;
using BioDataJWT.Utilitys;

namespace BioDataJWT.IService
{
    public interface IAuthenticationService
    {
        public Task<APIResponse<string>> Login(LoginDto login);

    }
}
