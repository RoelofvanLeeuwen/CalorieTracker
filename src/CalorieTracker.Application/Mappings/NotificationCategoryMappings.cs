using CalorieTracker.Application.Enums;
using CalorieTracker.Domain.Enums;

namespace CalorieTracker.Application.Mappings;

public static class NotificationCategoryMappings
{
    public static NotificationCategoryDto ToDto(this NotificationCategory category) => category switch
    {
        NotificationCategory.DailyGoalExceeded => NotificationCategoryDto.DailyGoalExceeded,
        NotificationCategory.NoEntryToday      => NotificationCategoryDto.NoEntryToday,
        _                                      => throw new ArgumentOutOfRangeException(nameof(category))
    };

    public static NotificationCategory ToDomain(this NotificationCategoryDto dto) => dto switch
    {
        NotificationCategoryDto.DailyGoalExceeded => NotificationCategory.DailyGoalExceeded,
        NotificationCategoryDto.NoEntryToday      => NotificationCategory.NoEntryToday,
        _                                         => throw new ArgumentOutOfRangeException(nameof(dto))
    };
}
