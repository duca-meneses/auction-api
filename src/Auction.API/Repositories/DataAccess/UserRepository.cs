using AppAuction.API.Contracts;
using AppAuction.API.Entities;

namespace AppAuction.API.Repositories.DataAccess;

public class UserRepository : IUserRepository
{

    private readonly AppAuctionDbContext _dbContext;

    public UserRepository(AppAuctionDbContext dbContext) => _dbContext = dbContext;

    public bool ExistWithEmail(string email)
    {
        return _dbContext.Users.Any(user => user.Email.Equals(email));
    }

    public User GetUserByEmail(string email)
    {
        return _dbContext.Users.First(user => user.Email.Equals(email));
    }
}
