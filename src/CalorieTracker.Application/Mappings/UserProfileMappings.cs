using CalorieTracker.Application.DTOs;
using CalorieTracker.Domain.Entities;

namespace CalorieTracker.Application.Mappings;

public static class UserProfileMappings
{
    public static UserProfileDto ToDto(this UserProfile profile) =>
        new(
            profile.Id,
            profile.WeightKg,
            profile.HeightCm,
            profile.AgeYears,
            profile.Gender.ToDto(),
            profile.ActivityLevel.ToDto(),
            profile.GoalType.ToDto(),
            profile.MacroProfile.ToDto()
        );
}
