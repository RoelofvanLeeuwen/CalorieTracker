using CalorieTracker.Application.Enums;

namespace CalorieTracker.Application.DTOs;

public record NotificationDto(
    int                     Id,
    NotificationCategoryDto Category,
    string                  Message,
    DateTime                CreatedAt,
    bool                    IsRead,
    DateOnly                ForDate
);
