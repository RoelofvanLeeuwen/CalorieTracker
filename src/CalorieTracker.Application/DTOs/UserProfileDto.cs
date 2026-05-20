using CalorieTracker.Application.Enums;

namespace CalorieTracker.Application.DTOs;

public record UserProfileDto(
    int             Id,
    decimal         WeightKg,
    int             HeightCm,
    int             AgeYears,
    GenderDto       Gender,
    ActivityLevelDto ActivityLevel,
    GoalTypeDto     GoalType,
    MacroProfileDto MacroProfile
);
