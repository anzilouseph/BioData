using System.Runtime.CompilerServices;
using BioDataJWT.Context;
using BioDataJWT.Dto;
using BioDataJWT.IRepo;
using BioDataJWT.Model;
using Dapper;

namespace BioDataJWT.Repo
{
    public class AuthenticationRepo : IAuthenticationRepo
    {
        private readonly DapperContext _context;

        public AuthenticationRepo(DapperContext context)
        {
            _context = context;
        }

        //for login
        public async Task<BioData> Login(LoginDto login)
        {
            var query = "select * from BioData where Email=@email";
            var parameters = new DynamicParameters();
            parameters.Add("email",login.emailOfUser);

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<BioData>(query,parameters);
                connection.Close();
                return result;
            }
        }
    }
}
