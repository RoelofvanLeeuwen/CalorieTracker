using CalorieTracker.Application.DTOs;
using CalorieTracker.Application.Enums;

namespace CalorieTracker.Application.Services;

public static class DailyGoalCalculator
{
    public static DailyGoalDto Calculate(UserProfileDto profile)
    {
        decimal bmr = profile.Gender == GenderDto.Male
            ? 10m * profile.WeightKg + 6.25m * profile.HeightCm - 5m * profile.AgeYears + 5m
            : 10m * profile.WeightKg + 6.25m * profile.HeightCm - 5m * profile.AgeYears - 161m;

        decimal activityFactor = profile.ActivityLevel switch
        {
            ActivityLevelDto.Sedentary  => 1.2m,
            ActivityLevelDto.Light      => 1.375m,
            ActivityLevelDto.Moderate   => 1.55m,
            ActivityLevelDto.Active     => 1.725m,
            ActivityLevelDto.VeryActive => 1.9m,
            _                           => 1.2m
        };

        decimal tdee = bmr * activityFactor;

        decimal goalAdjustment = profile.GoalType switch
        {
            GoalTypeDto.Lose     => -500m,
            GoalTypeDto.Maintain => 0m,
            GoalTypeDto.Gain     => 300m,
            _                    => 0m
        };

        decimal targetKcal = Math.Max(1200m, tdee + goalAdjustment);

        (decimal carbsPct, decimal fatPct, decimal proteinPct) = profile.MacroProfile switch
        {
            MacroProfileDto.Balanced    => (0.50m, 0.25m, 0.25m),
            MacroProfileDto.Athletic    => (0.55m, 0.20m, 0.25m),
            MacroProfileDto.HighProtein => (0.30m, 0.25m, 0.45m),
            MacroProfileDto.LowCarb     => (0.20m, 0.45m, 0.35m),
            MacroProfileDto.Keto        => (0.05m, 0.70m, 0.25m),
            _                           => (0.50m, 0.25m, 0.25m)
        };

        return new DailyGoalDto(
            TotalKcal:    Math.Round(targetKcal, 0),
            CarbsGrams:   Math.Round(targetKcal * carbsPct / 4m, 0),
            FatGrams:     Math.Round(targetKcal * fatPct  / 9m, 0),
            ProteinGrams: Math.Round(targetKcal * proteinPct / 4m, 0)
        );
    }
}
