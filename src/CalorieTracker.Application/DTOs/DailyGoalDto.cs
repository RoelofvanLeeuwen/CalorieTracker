namespace CalorieTracker.Application.DTOs;

public record DailyGoalDto(
    decimal TotalKcal,
    decimal CarbsGrams,
    decimal FatGrams,
    decimal ProteinGrams
);
