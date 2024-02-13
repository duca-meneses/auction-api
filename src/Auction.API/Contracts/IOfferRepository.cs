using AppAuction.API.Entities;

namespace AppAuction.API.Contracts;

public interface IOfferRepository
{
    void Add(Offer offer);
}
