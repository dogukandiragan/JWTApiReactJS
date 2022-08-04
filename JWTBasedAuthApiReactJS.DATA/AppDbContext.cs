using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JWTBasedAuthApiReactJS.CORE.Models;
using JWTBasedAuthApiReactJS.CORE.Configuration;

namespace JWTBasedAuthApiReactJS.DATA
{
    public class AppDbContext : IdentityDbContext<UserApp, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<TransactionApp> Transactions { get; set; }
        public DbSet<CustomerApp> Customers { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TransactionConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
     

            base.OnModelCreating(builder);
        }
    }
}