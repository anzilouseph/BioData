using BioDataJWT.Model;

namespace BioDataJWT.IRepo
{
    public interface IAdminManagementRepo
    {
        //ALL the APIS here can only accessed by admin

        public Task<BioData> GetById(Guid id); //first we need to craete this api before anythig bcz in the controller we check the role of the user, so in that cases we use this API for it (we dont share the role in the token)
        public Task<IEnumerable<BioData>> GetAll(); //for get all users 

    }
}
