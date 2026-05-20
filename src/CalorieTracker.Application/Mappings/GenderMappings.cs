using CalorieTracker.Application.Enums;
using CalorieTracker.Domain.Enums;

namespace CalorieTracker.Application.Mappings;

public static class GenderMappings
{
    public static GenderDto ToDto(this Gender gender) => gender switch
    {
        Gender.Male   => GenderDto.Male,
        Gender.Female => GenderDto.Female,
        _             => throw new ArgumentOutOfRangeException(nameof(gender))
    };

    public static Gender ToDomain(this GenderDto dto) => dto switch
    {
        GenderDto.Male   => Gender.Male,
        GenderDto.Female => Gender.Female,
        _                => throw new ArgumentOutOfRangeException(nameof(dto))
    };

    public static string GetLabel(this GenderDto dto) => dto switch
    {
        GenderDto.Male   => "Man",
        GenderDto.Female => "Vrouw",
        _                => dto.ToString()
    };
}
