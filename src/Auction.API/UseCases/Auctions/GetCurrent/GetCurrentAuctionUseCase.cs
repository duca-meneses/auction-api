using AppAuction.API.Contracts;
using AppAuction.API.Entities;
using AppAuction.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AppAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    private readonly IAuctionRepository _repository;

    public GetCurrentAuctionUseCase(IAuctionRepository repository) => _repository = repository;

    public Auction? Execute() => _repository.GetCurrent();
}
