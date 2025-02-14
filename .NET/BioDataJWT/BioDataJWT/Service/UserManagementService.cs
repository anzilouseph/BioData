using System.Runtime.CompilerServices;
using BioDataJWT.Dto;
using BioDataJWT.IRepo;
using BioDataJWT.IService;
using BioDataJWT.Utilitys;
using Microsoft.Identity.Client;

namespace BioDataJWT.Service
{
    public class UserManagementService :IUserManagementService
    {
        private readonly IUserManagementRepo _repo;

        public UserManagementService(IUserManagementRepo repo)  //injecting the IthRepo so that we can the method in that IthRepo from here
        {
            _repo = repo;
        }

        //for Adding User
        public async Task<APIResponse<bool>> AddUser(UserForCreationDto user)
        {
            user.passwordOfUser=forPasswordHasing.HashPassword(user.passwordOfUser,out string salt);
            var rowAffected = await _repo.AddUser(user,salt);

            if(rowAffected==0)
            {
                return APIResponse<bool>.Error("User Not Added");
            }
            return APIResponse<bool>.Success(true, "User Added Successfully");
        }


        //for get own profile by id (ie here each user can get his own id but the getbyid in admin controller is admin can give anyones id as input and can access every users profile) 
        public async Task<APIResponse<UserToListDto>> getOwnData(Guid id)
        {
            var reslt = await _repo.getOwnData(id);
            if(reslt==null)
            {
                return APIResponse<UserToListDto>.Error("Invalid user id");
            }

            var masked = new UserToListDto
            {
                idOfUser = reslt.ID,
                nameOfUser = reslt.FullName,
                ageOfUser = reslt.Age,
                addressOfUser = reslt.Address,
                emailOfUser = reslt.Email,
                roleOfUser = reslt.Role,
            };

            return APIResponse<UserToListDto>.Success(masked, "Success"); 

        }

    }
}
