namespace CalorieTracker.Application.DTOs;

public record AddActivityDto(
    string   Name,
    int      DurationMinutes,
    decimal  KcalBurned,
    DateTime PerformedAt
);
