using AppAuction.API.Comunication.Request;
using AppAuction.API.Contracts;
using AppAuction.API.Entities;
using AppAuction.API.Repositories;
using AppAuction.API.Services;

namespace AppAuction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IOfferRepository _repository;

    public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository repository)
    {
        _loggedUser = loggedUser;
        _repository = repository;
    }

    public Offer Execute(int itemId, RequestCreateOfferJson request)
    {
        var user = _loggedUser.GetUserAuthorized();

        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id
        };
        _repository.Add(offer);

        return offer;
    }

}
