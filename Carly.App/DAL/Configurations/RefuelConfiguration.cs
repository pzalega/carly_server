using Carly.App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carly.App.DAL.Configurations
{
    internal sealed class RefuelConfiguration : IEntityTypeConfiguration<Refuel>
    {
        public void Configure(EntityTypeBuilder<Refuel> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.VehicleId).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.FuelLitres).IsRequired().HasPrecision(18,2);
            builder.Property(x => x.LitrePrice).IsRequired().HasPrecision(18,2);
            builder.Property(x => x.RefuelPrice).IsRequired().HasPrecision(18,2);
            builder.Property(x => x.RefuelDate).IsRequired();

        }
    }
}
