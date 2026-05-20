using CalorieTracker.Application.Enums;
using CalorieTracker.Domain.Enums;

namespace CalorieTracker.Application.Mappings;

public static class MealMomentMappings
{
    public static MealMomentDto ToDto(this MealMoment mm) => mm switch
    {
        MealMoment.Breakfast => MealMomentDto.Breakfast,
        MealMoment.Lunch     => MealMomentDto.Lunch,
        MealMoment.Dinner    => MealMomentDto.Dinner,
        MealMoment.Snack     => MealMomentDto.Snack,
        _ => throw new ArgumentOutOfRangeException(nameof(mm), mm, null),
    };

    public static MealMoment ToDomain(this MealMomentDto mm) => mm switch
    {
        MealMomentDto.Breakfast => MealMoment.Breakfast,
        MealMomentDto.Lunch     => MealMoment.Lunch,
        MealMomentDto.Dinner    => MealMoment.Dinner,
        MealMomentDto.Snack     => MealMoment.Snack,
        _ => throw new ArgumentOutOfRangeException(nameof(mm), mm, null),
    };

    public static string GetLabel(this MealMomentDto mm) => mm switch
    {
        MealMomentDto.Breakfast => "Ontbijt",
        MealMomentDto.Lunch     => "Lunch",
        MealMomentDto.Dinner    => "Diner",
        MealMomentDto.Snack     => "Tussendoor",
        _ => mm.ToString(),
    };
}
