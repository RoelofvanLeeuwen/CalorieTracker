using CalorieTracker.Application.DTOs;
using CalorieTracker.Application.Enums;
using CalorieTracker.Application.Interfaces;
using CalorieTracker.Application.Mappings;
using CalorieTracker.Domain.Entities;
using CalorieTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Infrastructure.Repositories;

public class NotificationRepository(ApplicationDbContext context) : INotificationRepository
{
    public async Task<IReadOnlyList<NotificationDto>> GetAllAsync(CancellationToken ct = default) =>
        await context.Notifications
            .OrderByDescending(n => n.CreatedAt)
            .Select(n => new NotificationDto(n.Id, n.Category.ToDto(), n.Message, n.CreatedAt, n.IsRead, n.ForDate))
            .ToListAsync(ct);

    public async Task<int> GetUnreadCountAsync(CancellationToken ct = default) =>
        await context.Notifications.CountAsync(n => !n.IsRead, ct);

    public async Task<NotificationDto?> FindForDateAsync(NotificationCategoryDto category, DateOnly date, CancellationToken ct = default)
    {
        var domainCategory = category.ToDomain();
        var n = await context.Notifications
            .AsNoTracking()
            .FirstOrDefaultAsync(n => n.Category == domainCategory && n.ForDate == date, ct);
        return n is null ? null : new NotificationDto(n.Id, n.Category.ToDto(), n.Message, n.CreatedAt, n.IsRead, n.ForDate);
    }

    public async Task<NotificationDto> CreateAsync(NotificationCategoryDto category, string message, DateOnly forDate, CancellationToken ct = default)
    {
        var notification = Notification.Create(category.ToDomain(), message, forDate);
        context.Notifications.Add(notification);
        await context.SaveChangesAsync(ct);
        return new NotificationDto(notification.Id, notification.Category.ToDto(), notification.Message, notification.CreatedAt, notification.IsRead, notification.ForDate);
    }

    public async Task MarkAsReadAsync(int id, CancellationToken ct = default)
    {
        var n = await context.Notifications.FindAsync([id], ct)
            ?? throw new InvalidOperationException($"Notification {id} niet gevonden.");
        n.MarkAsRead();
        await context.SaveChangesAsync(ct);
    }

    public async Task MarkAllAsReadAsync(CancellationToken ct = default)
    {
        await context.Notifications
            .Where(n => !n.IsRead)
            .ExecuteUpdateAsync(s => s.SetProperty(n => n.IsRead, true), ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        await context.Notifications
            .Where(n => n.Id == id)
            .ExecuteDeleteAsync(ct);
    }
}
