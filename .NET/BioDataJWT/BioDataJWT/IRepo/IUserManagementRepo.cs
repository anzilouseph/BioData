using BioDataJWT.Dto;
using BioDataJWT.Model;

namespace BioDataJWT.IRepo
{
    public interface IUserManagementRepo
    {
        public Task<int> AddUser(UserForCreationDto user,string salt);  //for add user
        public Task<BioData> getOwnData(Guid id); //for get own profile by id (ie here each user can get his own id but the getbyid in admin controller is admin can give anyones id as input and can access every users profile) 

    }
}
