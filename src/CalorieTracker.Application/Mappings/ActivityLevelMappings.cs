using CalorieTracker.Application.Enums;
using CalorieTracker.Domain.Enums;

namespace CalorieTracker.Application.Mappings;

public static class ActivityLevelMappings
{
    public static ActivityLevelDto ToDto(this ActivityLevel level) => level switch
    {
        ActivityLevel.Sedentary  => ActivityLevelDto.Sedentary,
        ActivityLevel.Light      => ActivityLevelDto.Light,
        ActivityLevel.Moderate   => ActivityLevelDto.Moderate,
        ActivityLevel.Active     => ActivityLevelDto.Active,
        ActivityLevel.VeryActive => ActivityLevelDto.VeryActive,
        _                        => throw new ArgumentOutOfRangeException(nameof(level))
    };

    public static ActivityLevel ToDomain(this ActivityLevelDto dto) => dto switch
    {
        ActivityLevelDto.Sedentary  => ActivityLevel.Sedentary,
        ActivityLevelDto.Light      => ActivityLevel.Light,
        ActivityLevelDto.Moderate   => ActivityLevel.Moderate,
        ActivityLevelDto.Active     => ActivityLevel.Active,
        ActivityLevelDto.VeryActive => ActivityLevel.VeryActive,
        _                           => throw new ArgumentOutOfRangeException(nameof(dto))
    };

    public static string GetLabel(this ActivityLevelDto dto) => dto switch
    {
        ActivityLevelDto.Sedentary  => "Zittend",
        ActivityLevelDto.Light      => "Licht actief",
        ActivityLevelDto.Moderate   => "Matig actief",
        ActivityLevelDto.Active     => "Actief",
        ActivityLevelDto.VeryActive => "Zeer actief",
        _                           => dto.ToString()
    };

    public static string GetDescription(this ActivityLevelDto dto) => dto switch
    {
        ActivityLevelDto.Sedentary  => "Kantoorwerk, nauwelijks beweging",
        ActivityLevelDto.Light      => "1–3 keer per week lichte sport",
        ActivityLevelDto.Moderate   => "3–5 keer per week matige sport",
        ActivityLevelDto.Active     => "6–7 keer per week intensieve sport",
        ActivityLevelDto.VeryActive => "Dagelijks zwaar werk of topsport",
        _                           => string.Empty
    };
}
