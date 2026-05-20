using CalorieTracker.Application.Enums;

namespace CalorieTracker.Application.DTOs;

public record AddConsumptionDto(
    int           ProductId,
    decimal       Quantity,
    MealMomentDto MealMoment,
    DateTime      ConsumedAt);
