using CalorieTracker.Application.DTOs;
using CalorieTracker.Application.Interfaces;
using CalorieTracker.Domain.Entities;
using CalorieTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Infrastructure.Repositories;

public class ActivityRepository(ApplicationDbContext context) : IActivityRepository
{
    public async Task<DayActivityLogDto> GetDayLogAsync(DateOnly date, CancellationToken ct = default)
    {
        var start = date.ToDateTime(TimeOnly.MinValue);
        var end   = date.ToDateTime(TimeOnly.MaxValue);

        var activities = await context.Activities
            .Where(a => a.PerformedAt >= start && a.PerformedAt <= end)
            .OrderBy(a => a.PerformedAt)
            .ToListAsync(ct);

        var dtos = activities
            .Select(a => new ActivityDto(a.Id, a.Name, a.DurationMinutes, a.KcalBurned, a.PerformedAt))
            .ToList();

        return new DayActivityLogDto(dtos, dtos.Sum(a => a.KcalBurned));
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        var activity = await context.Activities.FindAsync([id], ct)
            ?? throw new InvalidOperationException($"Activity {id} niet gevonden.");
        context.Activities.Remove(activity);
        await context.SaveChangesAsync(ct);
    }

    public async Task<ActivityDto> AddAsync(AddActivityDto dto, CancellationToken ct = default)
    {
        var activity = Activity.Create(dto.Name, dto.DurationMinutes, dto.KcalBurned, dto.PerformedAt);
        context.Activities.Add(activity);
        await context.SaveChangesAsync(ct);
        return new ActivityDto(activity.Id, activity.Name, activity.DurationMinutes, activity.KcalBurned, activity.PerformedAt);
    }
}
