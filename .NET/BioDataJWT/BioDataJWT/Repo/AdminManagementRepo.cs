using BioDataJWT.Context;
using BioDataJWT.IRepo;
using BioDataJWT.Model;
using Dapper;
using Microsoft.AspNetCore.Mvc.Razor;

namespace BioDataJWT.Repo
{
    public class AdminManagementRepo : IAdminManagementRepo
    {
        private readonly DapperContext _context;

        public AdminManagementRepo(DapperContext context)
        {
            _context = context;
        }

        //for get By Id
        public async Task<BioData> GetById(Guid id)
        {
            var query = "select * from BioData where ID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<BioData>(query,parameters);  
                connection.Close();
                return result;
            }
        }



        //for GetAll by admin
        public async Task<IEnumerable<BioData>> GetAll()
        {
            var query = "select * from BioData";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryAsync<BioData>(query);
                connection.Close();
                return result;
            }
        }
        
    }
}
