using CalorieTracker.Application.Enums;

namespace CalorieTracker.Application.DTOs;

public record MealMomentLogDto(
    MealMomentDto                    MealMoment,
    string                           Label,
    IReadOnlyList<ConsumptionEntryDto> Entries,
    decimal                          TotalKcal,
    decimal                          TotalCarbs,
    decimal                          TotalFat,
    decimal                          TotalProtein);
