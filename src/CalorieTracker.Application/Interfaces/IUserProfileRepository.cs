using CalorieTracker.Application.DTOs;

namespace CalorieTracker.Application.Interfaces;

public interface IUserProfileRepository
{
    Task<UserProfileDto?> GetAsync(CancellationToken ct = default);
    Task<UserProfileDto>  SaveAsync(UpdateUserProfileDto dto, CancellationToken ct = default);
}
