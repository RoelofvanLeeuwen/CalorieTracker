using CalorieTracker.Application.Enums;

namespace CalorieTracker.Application.DTOs;

public record ProductDto(
    int      Id,
    string   Name,
    decimal  KcalPer100g,
    decimal  CarbsPer100g,
    decimal  FatPer100g,
    decimal  ProteinPer100g,
    UnitTypeDto DefaultUnit,
    string?  UnitLabel,
    decimal? GramsPerUnit);
