using AppAuction.API.Comunication.Request;
using AppAuction.API.Contracts;
using AppAuction.API.Entities;
using AppAuction.API.Services;
using AppAuction.API.UseCases.Offers.CreateOffer;
using Bogus;
using FluentAssertions;
using Moq;
using Xunit;

namespace UsesCases.Test.Offers.CreateOffer;
public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {
        //ARRANGE
        var request = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, faker => faker.Random.Decimal(50, 1000)).Generate();

        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(i => i.GetUserAuthorized()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

        //ACT
        var offer = useCase.Execute(itemId, request);
        var act  = () => useCase.Execute(itemId, request);

        //ASSERT
        offer.Should().NotBeNull();
        offer.Price.Should().Be(request.Price);
        act.Should().NotThrow();
    }
}
