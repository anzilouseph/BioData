using BioDataJWT.Dto;
using BioDataJWT.IRepo;
using BioDataJWT.IService;
using BioDataJWT.Utilitys;

namespace BioDataJWT.Service
{
    public class AdminManagementService : IAdminManagementService
    {
        private readonly IAdminManagementRepo _repo;

        public AdminManagementService(IAdminManagementRepo repo)
        {
            _repo = repo;
        }

        //for getById
        public async Task<APIResponse<UserToListDto>> GetByID(Guid id)
        {
            var result = await _repo.GetById(id);
            if(result == null)
            {
                return APIResponse<UserToListDto>.Error("Invalid ID");
            }
            var masked = new UserToListDto
            {
                idOfUser = result.ID,
                nameOfUser = result.FullName,
                ageOfUser = result.Age,
                addressOfUser = result.Address,
                emailOfUser = result.Email,
                roleOfUser = result.Role,
            };
            return APIResponse<UserToListDto>.Success(masked, "Success");
        }




        //for Get All Users (only admin can see it thats why give it in the Admin Managment
        public async Task<APIResponse<IEnumerable<UserToListDto>>> GetAll()
        {
            var result = await _repo.GetAll();
            if(result.Count()==0)
            {
                return APIResponse<IEnumerable<UserToListDto>>.Error("No tasks to show");
            }

            var masked = result.Select(user => new UserToListDto
            {
                idOfUser=user.ID,
                nameOfUser = user.FullName,
                ageOfUser = user.Age,
                addressOfUser = user.Address,
                emailOfUser = user.Email,
                roleOfUser = user.Role,
            });

            return APIResponse<IEnumerable<UserToListDto>>.Success(masked, "Success");
        }
    }


   
}
