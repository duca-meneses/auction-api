using AppAuction.API.Contracts;
using AppAuction.API.Entities;

namespace AppAuction.API.Repositories.DataAccess;

public class OfferRepository : IOfferRepository
{

    private readonly AppAuctionDbContext _dbContext;

    public OfferRepository(AppAuctionDbContext dbContext) => _dbContext = dbContext; 
    
    public void Add(Offer offer)
    {
        _dbContext.Offers.Add(offer);
        _dbContext.SaveChanges();
    }
}
