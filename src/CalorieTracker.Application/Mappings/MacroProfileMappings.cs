using CalorieTracker.Application.Enums;
using CalorieTracker.Domain.Enums;

namespace CalorieTracker.Application.Mappings;

public static class MacroProfileMappings
{
    public static MacroProfileDto ToDto(this MacroProfile profile) => profile switch
    {
        MacroProfile.Balanced    => MacroProfileDto.Balanced,
        MacroProfile.Athletic    => MacroProfileDto.Athletic,
        MacroProfile.HighProtein => MacroProfileDto.HighProtein,
        MacroProfile.LowCarb     => MacroProfileDto.LowCarb,
        MacroProfile.Keto        => MacroProfileDto.Keto,
        _                        => throw new ArgumentOutOfRangeException(nameof(profile))
    };

    public static MacroProfile ToDomain(this MacroProfileDto dto) => dto switch
    {
        MacroProfileDto.Balanced    => MacroProfile.Balanced,
        MacroProfileDto.Athletic    => MacroProfile.Athletic,
        MacroProfileDto.HighProtein => MacroProfile.HighProtein,
        MacroProfileDto.LowCarb     => MacroProfile.LowCarb,
        MacroProfileDto.Keto        => MacroProfile.Keto,
        _                           => throw new ArgumentOutOfRangeException(nameof(dto))
    };

    public static string GetLabel(this MacroProfileDto dto) => dto switch
    {
        MacroProfileDto.Balanced    => "Gebalanceerd",
        MacroProfileDto.Athletic    => "Sportief",
        MacroProfileDto.HighProtein => "Hoog eiwit",
        MacroProfileDto.LowCarb     => "Low-carb",
        MacroProfileDto.Keto        => "Keto",
        _                           => dto.ToString()
    };

    public static string GetDescription(this MacroProfileDto dto) => dto switch
    {
        MacroProfileDto.Balanced    => "50% koolh. · 25% vet · 25% eiwit — gezonde basis voor de meeste mensen",
        MacroProfileDto.Athletic    => "55% koolh. · 20% vet · 25% eiwit — regelmatig sporten, extra koolhydraten als brandstof",
        MacroProfileDto.HighProtein => "30% koolh. · 25% vet · 45% eiwit — krachttraining, spierbehoud bij gewichtsafname",
        MacroProfileDto.LowCarb     => "20% koolh. · 45% vet · 35% eiwit — stabiel bloedsuiker, gewichtsafname",
        MacroProfileDto.Keto        => "5% koolh. · 70% vet · 25% eiwit — strikt ketogeen, medische/speciale doeleinden",
        _                           => string.Empty
    };
}
