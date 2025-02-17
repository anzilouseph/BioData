using System.Runtime.CompilerServices;
using BioDataJWT.Dto;
using BioDataJWT.IRepo;
using BioDataJWT.IService;
using BioDataJWT.Model;
using BioDataJWT.Utilitys;
using Dapper;
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

        //update the profile of the user by himself
        public async Task<APIResponse<bool>> UpdateOwnData(UserForUpdationDto user, Guid id)
        {
            var queryBuilder = new List<string>();
            var parameters = new DynamicParameters();

            var binded = new BioData
            {
                FullName = user.nameOfUser,
                Age = user.ageOfUser,
                Address = user.addressOfUser,
                Email = user.emailOfUser
            };

            foreach (var prop in typeof(BioData).GetProperties())
            {
                if(prop.Name!="ID")
                {
                    var value = prop.GetValue(binded);
                    if(value != null)
                    {
                        if(!string.IsNullOrEmpty(value.ToString()) && value.ToString()!="0")
                        {
                            queryBuilder.Add($"{prop.Name}=@{prop.Name}");
                            parameters.Add($"{prop.Name}", value);
                        }
                    }
                }
            }

            if(queryBuilder.Count==0)
            {
                return APIResponse<bool>.Error("No fields to Update");
            }

            parameters.Add("id", id);

            var rowAffected = await _repo.UpdateOwnData(queryBuilder, parameters);
            if(rowAffected==0)
            {
                return APIResponse<bool>.Error("Unable to update");
            }
            return APIResponse<bool>.Success(true , "Success");
        }

    }
}
