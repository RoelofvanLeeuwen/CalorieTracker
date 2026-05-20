namespace CalorieTracker.Application.DTOs;

public record DayActivityLogDto(
    IReadOnlyList<ActivityDto> Activities,
    decimal                    TotalKcalBurned
);
