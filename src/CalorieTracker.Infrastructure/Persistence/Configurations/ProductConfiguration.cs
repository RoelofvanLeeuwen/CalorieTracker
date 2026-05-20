using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalorieTracker.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
        builder.HasIndex(p => p.Name).IsUnique();
        builder.Property(p => p.KcalPer100g)   .HasPrecision(8, 2);
        builder.Property(p => p.CarbsPer100g)  .HasPrecision(8, 2);
        builder.Property(p => p.FatPer100g)    .HasPrecision(8, 2);
        builder.Property(p => p.ProteinPer100g).HasPrecision(8, 2);
        builder.Property(p => p.GramsPerUnit)  .HasPrecision(8, 2);
        builder.Property(p => p.DefaultUnit).HasConversion<string>().HasMaxLength(10);
        builder.Property(p => p.UnitLabel).HasMaxLength(50);
    }
}
