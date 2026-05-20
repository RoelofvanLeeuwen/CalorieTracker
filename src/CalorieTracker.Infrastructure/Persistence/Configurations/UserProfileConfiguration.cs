using CalorieTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalorieTracker.Infrastructure.Persistence.Configurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.WeightKg).HasPrecision(5, 1);
        builder.Property(x => x.Gender).HasConversion<string>();
        builder.Property(x => x.ActivityLevel).HasConversion<string>();
        builder.Property(x => x.GoalType).HasConversion<string>();
        builder.Property(x => x.MacroProfile).HasConversion<string>();
    }
}
