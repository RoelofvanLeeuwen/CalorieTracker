using CalorieTracker.Application.DTOs;
using CalorieTracker.Domain.Entities;

namespace CalorieTracker.Application.Mappings;

public static class ProductMappings
{
    public static ProductDto ToDto(this Product p) => new(
        p.Id,
        p.Name,
        p.KcalPer100g,
        p.CarbsPer100g,
        p.FatPer100g,
        p.ProteinPer100g,
        p.DefaultUnit.ToDto(),
        p.UnitLabel,
        p.GramsPerUnit);
}
