using BioDataJWT.Dto;
using BioDataJWT.Utilitys;

namespace BioDataJWT.IService
{
    public interface IUserManagementService
    {
        public Task<APIResponse<bool>> AddUser(UserForCreationDto user);//for add user
        public Task<APIResponse<UserToListDto>> getOwnData(Guid id); //for get own profile by id (ie here each user can get his own id but the getbyid in admin controller is admin can give anyones id as input and can access every users profile) 
        public Task<APIResponse<bool>> UpdateOwnData(UserForUpdationDto user,Guid id); // for update the profile of the user by their own
    }
}
