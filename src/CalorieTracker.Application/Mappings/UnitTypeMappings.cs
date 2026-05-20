using CalorieTracker.Application.Enums;
using CalorieTracker.Domain.Enums;

namespace CalorieTracker.Application.Mappings;

public static class UnitTypeMappings
{
    public static UnitTypeDto ToDto(this UnitType ut) => ut switch
    {
        UnitType.Gram  => UnitTypeDto.Gram,
        UnitType.Piece => UnitTypeDto.Piece,
        _ => throw new ArgumentOutOfRangeException(nameof(ut), ut, null),
    };

    public static UnitType ToDomain(this UnitTypeDto ut) => ut switch
    {
        UnitTypeDto.Gram  => UnitType.Gram,
        UnitTypeDto.Piece => UnitType.Piece,
        _ => throw new ArgumentOutOfRangeException(nameof(ut), ut, null),
    };

    public static string GetLabel(this UnitTypeDto ut) => ut switch
    {
        UnitTypeDto.Gram  => "gram",
        UnitTypeDto.Piece => "eenheid",
        _ => ut.ToString(),
    };
}
