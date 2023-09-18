using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        DbSet<User> Users => Set<User>();
        DbSet<CoffeShop> CoffeShops => Set<CoffeShop>();
        DbSet<Coupon> CoffeCoupon => Set<Coupon>();
    }
}
