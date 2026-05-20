using CalorieTracker.Application.Enums;

namespace CalorieTracker.Application.DTOs;

public record CreateProductDto(
    string      Name,
    decimal     KcalPer100g,
    decimal     CarbsPer100g,
    decimal     FatPer100g,
    decimal     ProteinPer100g,
    UnitTypeDto DefaultUnit,
    string?     UnitLabel    = null,
    decimal?    GramsPerUnit = null);
