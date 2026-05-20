namespace CalorieTracker.Application.Services;

public record ActivityTemplate(string Name, decimal Met);

public static class ActivityTemplates
{
    public static readonly IReadOnlyList<ActivityTemplate> All =
    [
        new("Hardlopen (8 km/h)",          8.3m),
        new("Hardlopen (10 km/h)",         10.0m),
        new("Hardlopen (12 km/h)",         11.8m),
        new("Fietsen (matig, 16 km/h)",    6.0m),
        new("Fietsen (snel, 22 km/h)",     10.0m),
        new("Zwemmen",                     7.0m),
        new("Wandelen",                    3.5m),
        new("Wandelen (stevig)",           4.5m),
        new("Krachtraining",               5.0m),
        new("Yoga",                        3.0m),
        new("Voetbal",                     7.0m),
        new("Tennis",                      7.3m),
        new("Roeimachine",                 7.0m),
        new("Aerobics",                    6.5m),
        new("Touwtjespringen",             10.0m),
        new("Dansen",                      4.8m),
        new("Skiën",                       5.3m),
        new("Basketbal",                   6.5m),
    ];

    public static IReadOnlyList<ActivityTemplate> Search(string query) =>
        string.IsNullOrWhiteSpace(query)
            ? []
            : All.Where(t => t.Name.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();

    public static decimal CalculateKcal(decimal met, decimal weightKg, int durationMinutes) =>
        Math.Round(met * weightKg * (durationMinutes / 60m), 0);
}
