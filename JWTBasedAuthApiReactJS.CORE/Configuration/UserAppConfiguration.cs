using JWTBasedAuthApiReactJS.CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JWTBasedAuthApiReactJS.CORE.Configuration
{
    public class
        UserAppConfiguration : IEntityTypeConfiguration<UserApp>
    {
        public void Configure(EntityTypeBuilder<UserApp> builder)
        {
           //  builder.Property(x => x.City).HasMaxLength(50);


        }
    }
}