using CalorieTracker.Application.DTOs;

namespace CalorieTracker.Application.Interfaces;

public interface INotificationService
{
    Task<(NotificationDto? OverDailyGoal, NotificationDto? NoEntry)> EvaluateAsync(
        DateOnly date,
        bool     isOverDailyGoal,
        string   overDailyGoalMessage,
        bool     hasEntries,
        CancellationToken ct = default);
}
