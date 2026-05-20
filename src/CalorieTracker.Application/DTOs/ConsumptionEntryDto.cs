using CalorieTracker.Application.Enums;

namespace CalorieTracker.Application.DTOs;

public record ConsumptionEntryDto(
    int         Id,
    ProductDto  Product,
    decimal     Quantity,
    MealMomentDto MealMoment,
    DateTime    ConsumedAt,
    decimal     TotalGrams,
    decimal     TotalKcal,
    decimal     TotalCarbs,
    decimal     TotalFat,
    decimal     TotalProtein);
