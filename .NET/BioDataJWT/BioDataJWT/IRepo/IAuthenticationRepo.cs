using BioDataJWT.Dto;
using BioDataJWT.Model;

namespace BioDataJWT.IRepo
{
    public interface IAuthenticationRepo
    {
        public Task<BioData> Login(LoginDto login);  //for login
    }
}
