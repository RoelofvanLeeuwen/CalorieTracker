using CalorieTracker.Application.DTOs;
using CalorieTracker.Application.Enums;

namespace CalorieTracker.Application.Interfaces;

public interface INotificationRepository
{
    Task<IReadOnlyList<NotificationDto>> GetAllAsync(CancellationToken ct = default);
    Task<int>                            GetUnreadCountAsync(CancellationToken ct = default);
    Task<NotificationDto?>               FindForDateAsync(NotificationCategoryDto category, DateOnly date, CancellationToken ct = default);
    Task<NotificationDto>                CreateAsync(NotificationCategoryDto category, string message, DateOnly forDate, CancellationToken ct = default);
    Task                                 MarkAsReadAsync(int id, CancellationToken ct = default);
    Task                                 MarkAllAsReadAsync(CancellationToken ct = default);
    Task                                 DeleteAsync(int id, CancellationToken ct = default);
}
