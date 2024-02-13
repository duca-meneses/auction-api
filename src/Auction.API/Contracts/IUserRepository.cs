using AppAuction.API.Entities;

namespace AppAuction.API.Contracts;

public interface IUserRepository
{
    bool ExistWithEmail(string email);
    User GetUserByEmail(string email);
}
