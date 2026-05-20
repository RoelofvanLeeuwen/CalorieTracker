using CalorieTracker.Application.DTOs;
using CalorieTracker.Application.Interfaces;
using CalorieTracker.Application.Mappings;
using CalorieTracker.Domain.Entities;
using CalorieTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Infrastructure.Repositories;

public class UserProfileRepository(ApplicationDbContext context) : IUserProfileRepository
{
    public async Task<UserProfileDto?> GetAsync(CancellationToken ct = default)
    {
        var profile = await context.UserProfiles.FirstOrDefaultAsync(ct);
        return profile?.ToDto();
    }

    public async Task<UserProfileDto> SaveAsync(UpdateUserProfileDto dto, CancellationToken ct = default)
    {
        var existing = await context.UserProfiles.FirstOrDefaultAsync(ct);

        if (existing is null)
        {
            existing = UserProfile.Create(
                dto.WeightKg, dto.HeightCm, dto.AgeYears,
                dto.Gender.ToDomain(), dto.ActivityLevel.ToDomain(),
                dto.GoalType.ToDomain(), dto.MacroProfile.ToDomain());
            context.UserProfiles.Add(existing);
        }
        else
        {
            existing.Update(
                dto.WeightKg, dto.HeightCm, dto.AgeYears,
                dto.Gender.ToDomain(), dto.ActivityLevel.ToDomain(),
                dto.GoalType.ToDomain(), dto.MacroProfile.ToDomain());
        }

        await context.SaveChangesAsync(ct);
        return existing.ToDto();
    }
}
