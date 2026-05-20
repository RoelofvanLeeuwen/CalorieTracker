using CalorieTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalorieTracker.Infrastructure.Persistence.Configurations;

public class ConsumptionEntryConfiguration : IEntityTypeConfiguration<ConsumptionEntry>
{
    public void Configure(EntityTypeBuilder<ConsumptionEntry> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Quantity).HasPrecision(10, 3);
        builder.Property(e => e.MealMoment).HasConversion<string>().HasMaxLength(15);
        builder.Property(e => e.ConsumedAt).IsRequired();
        builder.HasOne(e => e.Product)
               .WithMany()
               .HasForeignKey(e => e.ProductId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
