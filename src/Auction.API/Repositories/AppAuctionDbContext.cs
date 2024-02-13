using AppAuction.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppAuction.API.Repositories;

public class AppAuctionDbContext : DbContext
{
    public AppAuctionDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }  
    public DbSet<Offer> Offers { get; set; }  

}
    