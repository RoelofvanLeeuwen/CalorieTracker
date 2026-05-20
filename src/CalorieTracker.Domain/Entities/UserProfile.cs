using CalorieTracker.Domain.Common;
using CalorieTracker.Domain.Enums;

namespace CalorieTracker.Domain.Entities;

public class UserProfile : EntityBase
{
    private UserProfile() { }

    public decimal WeightKg       { get; private set; }
    public int     HeightCm       { get; private set; }
    public int     AgeYears       { get; private set; }
    public Gender        Gender        { get; private set; }
    public ActivityLevel ActivityLevel { get; private set; }
    public GoalType      GoalType      { get; private set; }
    public MacroProfile  MacroProfile  { get; private set; }

    public static UserProfile Create(
        decimal weightKg, int heightCm, int ageYears,
        Gender gender, ActivityLevel activityLevel,
        GoalType goalType, MacroProfile macroProfile) =>
        new()
        {
            WeightKg      = weightKg,
            HeightCm      = heightCm,
            AgeYears      = ageYears,
            Gender        = gender,
            ActivityLevel = activityLevel,
            GoalType      = goalType,
            MacroProfile  = macroProfile
        };

    public void Update(
        decimal weightKg, int heightCm, int ageYears,
        Gender gender, ActivityLevel activityLevel,
        GoalType goalType, MacroProfile macroProfile)
    {
        WeightKg      = weightKg;
        HeightCm      = heightCm;
        AgeYears      = ageYears;
        Gender        = gender;
        ActivityLevel = activityLevel;
        GoalType      = goalType;
        MacroProfile  = macroProfile;
    }
}
