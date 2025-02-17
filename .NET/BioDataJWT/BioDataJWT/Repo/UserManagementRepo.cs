using System.ComponentModel;
using System.Data;
using System.Linq.Expressions;
using BioDataJWT.Context;
using BioDataJWT.Dto;
using BioDataJWT.IRepo;
using BioDataJWT.Model;
using Dapper;

namespace BioDataJWT.Repo
{
    public class UserManagementRepo : IUserManagementRepo
    {
        private readonly DapperContext _context;  
        public UserManagementRepo(DapperContext context)  //injecting the dapper class to make the connection to the db
        {
            _context = context;
        }

        //for Adding User
        public async Task<int> AddUser(UserForCreationDto user,string salt)
        {
            var query = "addUser";
            var parameters = new DynamicParameters();
            parameters.Add("p_name", user.nameOfUser, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("p_age", user.ageOfUser, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameters.Add("p_address", user.addressOfUser, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("p_email", user.emailOfUser, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("p_password", user.passwordOfUser, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("p_salt",salt, System.Data.DbType.String, System.Data.ParameterDirection.Input);
               
            using(var connection=_context.CreateConnection())
            {
                connection.Open();
                var rowAffected = await connection.ExecuteAsync(query, parameters,commandType:CommandType.StoredProcedure);
                connection.Close();
                return rowAffected;
            }
        }



        //for get own profile by id (ie here each user can get his own id but the getbyid in admin controller is admin can give anyones id as input and can access every users profile) 
        public async Task<BioData> getOwnData(Guid id)
        {
            var query = "select * from BioData where ID=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using(var connection=_context.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<BioData>(query,parameters);
                connection.Close();
                return result;
            }
        }


        //for update the profile of the the user by himself
        public async Task<int> UpdateOwnData(List<string> queryBuilder, DynamicParameters parameters)
        {
            var query = $"update BioData set {string.Join(",", queryBuilder)} where ID=@id";
            using(var connection = _context.CreateConnection())
            {
                connection.Open();
                var rowAffected = await connection.ExecuteAsync(query, parameters);
                connection.Close();
                return rowAffected;
            }
        }



    }
}
