using CalorieTracker.Application.DTOs;

namespace CalorieTracker.Application.Interfaces;

public interface IActivityRepository
{
    Task<DayActivityLogDto> GetDayLogAsync(DateOnly date, CancellationToken ct = default);
    Task<ActivityDto>       AddAsync(AddActivityDto dto, CancellationToken ct = default);
}
