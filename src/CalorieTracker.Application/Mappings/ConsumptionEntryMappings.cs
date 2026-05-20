using CalorieTracker.Application.DTOs;
using CalorieTracker.Domain.Entities;

namespace CalorieTracker.Application.Mappings;

public static class ConsumptionEntryMappings
{
    public static ConsumptionEntryDto ToDto(this ConsumptionEntry e) => new(
        e.Id,
        e.Product.ToDto(),
        e.Quantity,
        e.MealMoment.ToDto(),
        e.ConsumedAt,
        e.TotalGrams,
        e.TotalKcal,
        e.TotalCarbs,
        e.TotalFat,
        e.TotalProtein);
}
