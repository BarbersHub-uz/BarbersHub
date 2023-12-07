using Microsoft.EntityFrameworkCore;
using BarbersHub.Domain.Entities.Users;
using BarbersHub.Domain.Entities.Orders;
using BarbersHub.Domain.Entities.Comments;
using BarbersHub.Domain.Entities.Assets;
using BarbersHub.Domain.Entities.Favorites;
using BarbersHub.Domain.Entities.BarberShops;

namespace BarbersHub.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<UserAsset> UserAssets { get; set; }
        public DbSet<Completed> Completeds { get; set; }
        public DbSet<BarberShop> BarberShops { get; set; }
        public DbSet<BarberStyle> BarberStyles { get; set; }
        public DbSet<BarberAsset> BarberAssets { get; set; }
        public DbSet<BarberShopAsset> BarberShopAssets { get; set; }
        public DbSet<BarberStyleAsset> BarberStyleAssets { get; set; }
    }
}
