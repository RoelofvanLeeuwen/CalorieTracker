using CalorieTracker.Domain.Common;
using CalorieTracker.Domain.Enums;

namespace CalorieTracker.Domain.Entities;

public class ConsumptionEntry : EntityBase
{
    private ConsumptionEntry() { }

    public int ProductId        { get; private set; }
    public Product Product      { get; private set; } = null!;
    public decimal Quantity     { get; private set; }
    public MealMoment MealMoment{ get; private set; }
    public DateTime ConsumedAt  { get; private set; }

    // Total gram depends on whether the product is unit- or weight-based.
    public decimal TotalGrams =>
        Product.DefaultUnit == UnitType.Piece
            ? Quantity * (Product.GramsPerUnit ?? 0m)
            : Quantity;

    public decimal TotalKcal    => TotalGrams / 100m * Product.KcalPer100g;
    public decimal TotalCarbs   => TotalGrams / 100m * Product.CarbsPer100g;
    public decimal TotalFat     => TotalGrams / 100m * Product.FatPer100g;
    public decimal TotalProtein => TotalGrams / 100m * Product.ProteinPer100g;

    public static ConsumptionEntry Create(
        Product product,
        decimal quantity,
        MealMoment mealMoment,
        DateTime consumedAt) => new()
    {
        Product    = product,
        ProductId  = product.Id,
        Quantity   = quantity,
        MealMoment = mealMoment,
        ConsumedAt = consumedAt,
    };
}
