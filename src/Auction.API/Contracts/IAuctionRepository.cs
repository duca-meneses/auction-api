using AppAuction.API.Entities;

namespace AppAuction.API.Contracts;

public interface IAuctionRepository
{
    Auction? GetCurrent();
}
