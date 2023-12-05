using Microsoft.EntityFrameworkCore;
using BarbersHub.Domain.Entities.Users;
using BarbersHub.Domain.Entities.Orders;
using BarbersHub.Domain.Entities.Comments;
using BarbersHub.Domain.Entities.Favorites;
using BarbersHub.Domain.Entities.BarberShops;

namespace BarbersHub.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    DbSet<User> Users { get; set; }
    DbSet<Barber> Barbers { get; set; }
    DbSet<BarberShop> BarberShops { get; set; }
    DbSet<BarberStyle> BarberStyles { get; set; }
    DbSet<Style> Styles { get; set; }
    DbSet<Favorite> Favorites { get; set; }
    DbSet<Comment> Comments { get; set; }
    DbSet<Completed> Completeds { get; set; }
    DbSet<Order> Orders { get; set; }
}
