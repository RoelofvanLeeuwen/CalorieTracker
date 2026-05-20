namespace CalorieTracker.Application.DTOs;

public record DayLogDto(
    DateOnly                         Date,
    IReadOnlyList<MealMomentLogDto>  MealMoments,
    decimal                          TotalKcal,
    decimal                          TotalCarbs,
    decimal                          TotalFat,
    decimal                          TotalProtein);
