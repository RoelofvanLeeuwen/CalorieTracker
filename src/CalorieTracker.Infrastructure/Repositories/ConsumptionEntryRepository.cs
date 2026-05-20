using CalorieTracker.Application.DTOs;
using CalorieTracker.Application.Interfaces;
using CalorieTracker.Application.Mappings;
using CalorieTracker.Domain.Entities;
using CalorieTracker.Domain.Enums;
using CalorieTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Infrastructure.Repositories;

public class ConsumptionEntryRepository(ApplicationDbContext context) : IConsumptionEntryRepository
{
    public async Task<DayLogDto> GetDayLogAsync(DateOnly date, CancellationToken ct = default)
    {
        var start = date.ToDateTime(TimeOnly.MinValue);
        var end   = date.ToDateTime(TimeOnly.MaxValue);

        var entries = await context.ConsumptionEntries
            .Include(e => e.Product)
            .Where(e => e.ConsumedAt >= start && e.ConsumedAt <= end)
            .OrderBy(e => e.ConsumedAt)
            .ToListAsync(ct);

        var mealMoments = Enum.GetValues<MealMoment>()
            .Select(mm =>
            {
                var mmEntries = entries
                    .Where(e => e.MealMoment == mm)
                    .Select(e => e.ToDto())
                    .ToList();

                return new MealMomentLogDto(
                    mm.ToDto(),
                    mm.ToDto().GetLabel(),
                    mmEntries,
                    mmEntries.Sum(e => e.TotalKcal),
                    mmEntries.Sum(e => e.TotalCarbs),
                    mmEntries.Sum(e => e.TotalFat),
                    mmEntries.Sum(e => e.TotalProtein));
            })
            .ToList();

        var allEntries = entries.Select(e => e.ToDto()).ToList();
        return new DayLogDto(
            date,
            mealMoments,
            allEntries.Sum(e => e.TotalKcal),
            allEntries.Sum(e => e.TotalCarbs),
            allEntries.Sum(e => e.TotalFat),
            allEntries.Sum(e => e.TotalProtein));
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        var entry = await context.ConsumptionEntries.FindAsync([id], ct)
            ?? throw new InvalidOperationException($"ConsumptionEntry {id} niet gevonden.");
        context.ConsumptionEntries.Remove(entry);
        await context.SaveChangesAsync(ct);
    }

    public async Task<ConsumptionEntryDto> AddAsync(AddConsumptionDto dto, CancellationToken ct = default)
    {
        var product = await context.Products.FindAsync([dto.ProductId], ct)
            ?? throw new InvalidOperationException($"Product {dto.ProductId} niet gevonden.");

        var entry = ConsumptionEntry.Create(product, dto.Quantity, dto.MealMoment.ToDomain(), dto.ConsumedAt);
        context.ConsumptionEntries.Add(entry);
        await context.SaveChangesAsync(ct);

        // Re-load with navigation property for correct DTO mapping.
        await context.Entry(entry).Reference(e => e.Product).LoadAsync(ct);
        return entry.ToDto();
    }
}
