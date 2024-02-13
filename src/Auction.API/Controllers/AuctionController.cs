using AppAuction.API.Entities;
using AppAuction.API.UseCases.Auctions.GetCurrent;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AppAuction.API.Controllers;

public class AuctionController : AppAuctionBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction([FromServices] GetCurrentAuctionUseCase useCase)
    {
        var result = useCase.Execute();

        if (result is null) 
            return NoContent();

        return Ok(result);
    }

}
