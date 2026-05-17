using WebApplication1.DTOs;

namespace WebApplication1.Services;

public interface IPcService
{
    Task<IEnumerable<PcGetAllDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<PcGetByIdDto> GetComponentsAsync(int id, CancellationToken cancellationToken);
    Task<PcGetAllDto> AddAsync(PcCreateDto request, CancellationToken cancellationToken);
    Task UpdateAsync(int id, PcUpdateDto request, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}