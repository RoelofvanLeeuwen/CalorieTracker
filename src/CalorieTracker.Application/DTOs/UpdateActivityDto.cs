namespace CalorieTracker.Application.DTOs;

public record UpdateActivityDto(string Name, int DurationMinutes, decimal KcalBurned, DateTime PerformedAt);
