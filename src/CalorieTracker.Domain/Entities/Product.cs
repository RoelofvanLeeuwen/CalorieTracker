using CalorieTracker.Domain.Common;
using CalorieTracker.Domain.Enums;

namespace CalorieTracker.Domain.Entities;

public class Product : EntityBase
{
    private Product() { }

    public string Name           { get; private set; } = string.Empty;
    public decimal KcalPer100g   { get; private set; }
    public decimal CarbsPer100g  { get; private set; }
    public decimal FatPer100g    { get; private set; }
    public decimal ProteinPer100g{ get; private set; }
    public UnitType DefaultUnit  { get; private set; }
    public string? UnitLabel     { get; private set; }
    public decimal? GramsPerUnit { get; private set; }

    public static Product CreateGramBased(
        string name,
        decimal kcalPer100g,
        decimal carbsPer100g,
        decimal fatPer100g,
        decimal proteinPer100g) => new()
    {
        Name            = name,
        KcalPer100g     = kcalPer100g,
        CarbsPer100g    = carbsPer100g,
        FatPer100g      = fatPer100g,
        ProteinPer100g  = proteinPer100g,
        DefaultUnit     = UnitType.Gram,
    };

    public static Product CreatePieceBased(
        string name,
        decimal kcalPer100g,
        decimal carbsPer100g,
        decimal fatPer100g,
        decimal proteinPer100g,
        string unitLabel,
        decimal gramsPerUnit) => new()
    {
        Name            = name,
        KcalPer100g     = kcalPer100g,
        CarbsPer100g    = carbsPer100g,
        FatPer100g      = fatPer100g,
        ProteinPer100g  = proteinPer100g,
        DefaultUnit     = UnitType.Piece,
        UnitLabel       = unitLabel,
        GramsPerUnit    = gramsPerUnit,
    };
}
