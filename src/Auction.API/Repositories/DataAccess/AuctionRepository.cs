using AppAuction.API.Contracts;
using AppAuction.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppAuction.API.Repositories.DataAccess;

public class AuctionRepository : IAuctionRepository
{
    private readonly AppAuctionDbContext _dbContext;

    public AuctionRepository(AppAuctionDbContext dbContext) => _dbContext = dbContext;

    public Auction? GetCurrent()
    {
        var today = DateTime.Now;
        return _dbContext
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }
}
