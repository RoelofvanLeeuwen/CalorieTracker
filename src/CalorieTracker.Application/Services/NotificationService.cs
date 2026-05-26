using CalorieTracker.Application.DTOs;
using CalorieTracker.Application.Enums;
using CalorieTracker.Application.Interfaces;

namespace CalorieTracker.Application.Services;

public class NotificationService(INotificationRepository repo) : INotificationService
{
    public async Task<(NotificationDto? OverDailyGoal, NotificationDto? NoEntry)> EvaluateAsync(
        DateOnly date,
        bool     isOverDailyGoal,
        string   overDailyGoalMessage,
        bool     hasEntries,
        CancellationToken ct = default)
    {
        NotificationDto? overDailyGoal = null;
        NotificationDto? noEntry       = null;

        if (isOverDailyGoal)
        {
            var existing = await repo.FindForDateAsync(NotificationCategoryDto.DailyGoalExceeded, date, ct);
            overDailyGoal = existing is { IsRead: false }
                ? existing
                : existing is null
                    ? await repo.CreateAsync(NotificationCategoryDto.DailyGoalExceeded, overDailyGoalMessage, date, ct)
                    : null; // bestaat maar al gelezen: niet heractiveren
        }
        else
        {
            var existing = await repo.FindForDateAsync(NotificationCategoryDto.DailyGoalExceeded, date, ct);
            if (existing is { IsRead: false })
                await repo.DeleteAsync(existing.Id, ct);
        }

        if (!hasEntries)
        {
            noEntry = await repo.FindForDateAsync(NotificationCategoryDto.NoEntryToday, date, ct)
                   ?? await repo.CreateAsync(NotificationCategoryDto.NoEntryToday, "Je hebt vandaag nog niets gelogd.", date, ct);
        }
        else
        {
            var existing = await repo.FindForDateAsync(NotificationCategoryDto.NoEntryToday, date, ct);
            if (existing is { IsRead: false })
                noEntry = existing;
        }

        return (overDailyGoal, noEntry);
    }
}
