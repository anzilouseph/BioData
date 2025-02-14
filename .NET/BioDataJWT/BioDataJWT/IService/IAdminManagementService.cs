using BioDataJWT.Dto;
using BioDataJWT.Utilitys;

namespace BioDataJWT.IService
{
    public interface IAdminManagementService
    {
        public Task<APIResponse<UserToListDto>> GetByID(Guid id);
        public Task<APIResponse<IEnumerable<UserToListDto>>> GetAll(); //for get all
    }
}
