using AppAuction.API.Comunication.Request;
using AppAuction.API.Entities;
using AppAuction.API.Filters;
using AppAuction.API.UseCases.Offers.CreateOffer;
using Microsoft.AspNetCore.Mvc;

namespace AppAuction.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : AppAuctionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    [ProducesResponseType(typeof(Offer), StatusCodes.Status201Created)]
    public IActionResult CreateOffer(
        [FromRoute] int itemId,
        [FromBody] RequestCreateOfferJson request,
        [FromServices] CreateOfferUseCase useCase)
    {
        var offer = useCase.Execute(itemId, request);

        return Created(string.Empty, offer);
    }   
}
