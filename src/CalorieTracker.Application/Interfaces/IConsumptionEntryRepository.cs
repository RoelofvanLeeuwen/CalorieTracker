using CalorieTracker.Application.DTOs;

namespace CalorieTracker.Application.Interfaces;

public interface IConsumptionEntryRepository
{
    Task<DayLogDto> GetDayLogAsync(DateOnly date, CancellationToken ct = default);
    Task<ConsumptionEntryDto> AddAsync(AddConsumptionDto dto, CancellationToken ct = default);
    Task DeleteAsync(int id, CancellationToken ct = default);
}
