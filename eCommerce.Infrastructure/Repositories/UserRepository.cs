using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly DapperDbContext _context;

    public UserRepository(DapperDbContext context)
    {
        _context = context;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserID = Guid.NewGuid();

        string query = "INSERT INTO public.\"users\"(\"userid\", \"email\", \"personname\", \"gender\", \"password\") " +
                       "Values (@UserID, @Email, @PersonName, @Gender, @Password)";
        
        int rowAffected = await _context.DbConnection.ExecuteAsync(query, user);

        if (rowAffected > 0)
            return user;
        
        return null;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    { 
        string query = "select * from public.\"users\" where \"email\" = @email and \"password\" = @password";
        
        ApplicationUser? user = await _context.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, new { email, password }); 
        
        return user;
    }
}