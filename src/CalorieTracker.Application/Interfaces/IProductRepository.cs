using CalorieTracker.Application.DTOs;

namespace CalorieTracker.Application.Interfaces;

public interface IProductRepository
{
    Task<IReadOnlyList<ProductDto>> SearchAsync(string query, CancellationToken ct = default);
    Task<ProductDto> CreateAsync(CreateProductDto dto, CancellationToken ct = default);
}
