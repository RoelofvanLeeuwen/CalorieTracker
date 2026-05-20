namespace CalorieTracker.Application.DTOs;

public record ActivityDto(
    int      Id,
    string   Name,
    int      DurationMinutes,
    decimal  KcalBurned,
    DateTime PerformedAt
);
