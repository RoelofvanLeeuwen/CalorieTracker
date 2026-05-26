using CalorieTracker.Domain.Common;
using CalorieTracker.Domain.Enums;

namespace CalorieTracker.Domain.Entities;

public class Notification : EntityBase
{
    private Notification() { }

    public NotificationCategory Category  { get; private set; }
    public string               Message   { get; private set; } = null!;
    public DateTime             CreatedAt { get; private set; }
    public bool                 IsRead    { get; private set; }
    public DateOnly             ForDate   { get; private set; }

    public static Notification Create(NotificationCategory category, string message, DateOnly forDate) =>
        new()
        {
            Category  = category,
            Message   = message,
            CreatedAt = DateTime.Now,
            IsRead    = false,
            ForDate   = forDate
        };

    public void MarkAsRead() => IsRead = true;
}
