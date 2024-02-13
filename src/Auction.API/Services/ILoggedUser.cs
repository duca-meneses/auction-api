using AppAuction.API.Entities;

namespace AppAuction.API.Services;

public interface ILoggedUser
{
    User GetUserAuthorized();
}
