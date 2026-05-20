using CalorieTracker.Domain.Common;

namespace CalorieTracker.Domain.Entities;

public class Activity : EntityBase
{
    private Activity() { }

    public string   Name            { get; private set; } = null!;
    public int      DurationMinutes { get; private set; }
    public decimal  KcalBurned      { get; private set; }
    public DateTime PerformedAt     { get; private set; }

    public static Activity Create(string name, int durationMinutes, decimal kcalBurned, DateTime performedAt) =>
        new()
        {
            Name            = name,
            DurationMinutes = durationMinutes,
            KcalBurned      = kcalBurned,
            PerformedAt     = performedAt
        };
}
