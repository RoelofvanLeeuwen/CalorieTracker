using CalorieTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalorieTracker.Infrastructure.Persistence.Configurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Message).HasMaxLength(500).IsRequired();
        builder.Property(x => x.Category).HasConversion<string>().HasMaxLength(50).IsRequired();
        builder.Property(x => x.ForDate).IsRequired();
        builder.HasIndex(x => new { x.Category, x.ForDate });
    }
}
