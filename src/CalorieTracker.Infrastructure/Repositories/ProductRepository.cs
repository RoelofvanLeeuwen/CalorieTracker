using CalorieTracker.Application.DTOs;
using CalorieTracker.Application.Interfaces;
using CalorieTracker.Application.Mappings;
using CalorieTracker.Domain.Entities;
using CalorieTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Infrastructure.Repositories;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    public async Task<IReadOnlyList<ProductDto>> SearchAsync(string query, CancellationToken ct = default)
    {
        var lower = query.ToLowerInvariant();
        return await context.Products
            .Where(p => p.Name.ToLower().Contains(lower))
            .OrderBy(p => p.Name)
            .Take(10)
            .Select(p => p.ToDto())
            .ToListAsync(ct);
    }

    public async Task<ProductDto> CreateAsync(CreateProductDto dto, CancellationToken ct = default)
    {
        var product = dto.DefaultUnit == Application.Enums.UnitTypeDto.Gram
            ? Product.CreateGramBased(dto.Name, dto.KcalPer100g, dto.CarbsPer100g, dto.FatPer100g, dto.ProteinPer100g)
            : Product.CreatePieceBased(dto.Name, dto.KcalPer100g, dto.CarbsPer100g, dto.FatPer100g, dto.ProteinPer100g, dto.UnitLabel!, dto.GramsPerUnit!.Value);

        context.Products.Add(product);
        await context.SaveChangesAsync(ct);
        return product.ToDto();
    }
}
