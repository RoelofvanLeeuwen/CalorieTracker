using CalorieTracker.Application.Enums;
using CalorieTracker.Domain.Enums;

namespace CalorieTracker.Application.Mappings;

public static class GoalTypeMappings
{
    public static GoalTypeDto ToDto(this GoalType goal) => goal switch
    {
        GoalType.Lose     => GoalTypeDto.Lose,
        GoalType.Maintain => GoalTypeDto.Maintain,
        GoalType.Gain     => GoalTypeDto.Gain,
        _                 => throw new ArgumentOutOfRangeException(nameof(goal))
    };

    public static GoalType ToDomain(this GoalTypeDto dto) => dto switch
    {
        GoalTypeDto.Lose     => GoalType.Lose,
        GoalTypeDto.Maintain => GoalType.Maintain,
        GoalTypeDto.Gain     => GoalType.Gain,
        _                    => throw new ArgumentOutOfRangeException(nameof(dto))
    };

    public static string GetLabel(this GoalTypeDto dto) => dto switch
    {
        GoalTypeDto.Lose     => "Afvallen (−500 kcal)",
        GoalTypeDto.Maintain => "Gewicht houden",
        GoalTypeDto.Gain     => "Aankomen (+300 kcal)",
        _                    => dto.ToString()
    };
}
