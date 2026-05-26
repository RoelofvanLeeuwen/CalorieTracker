namespace CalorieTracker.Web.Services;

public sealed class NotificationStateService
{
    public event Action? OnChanged;
    public int UnreadCount { get; private set; }

    public void Set(int unreadCount)
    {
        UnreadCount = unreadCount;
        OnChanged?.Invoke();
    }
}
