using CalorieTracker.Application.Enums;

namespace CalorieTracker.Application.DTOs;

public record UpdateUserProfileDto(
    decimal          WeightKg,
    int              HeightCm,
    int              AgeYears,
    GenderDto        Gender,
    ActivityLevelDto ActivityLevel,
    GoalTypeDto      GoalType,
    MacroProfileDto  MacroProfile
);
