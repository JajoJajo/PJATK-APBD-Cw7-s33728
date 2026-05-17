using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Infrastructure;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class PcService(DatabaseContext ctx) : IPcService
{
    public async Task<IEnumerable<PcGetAllDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await ctx.PCs.Select(
            p => new PcGetAllDto
            {
                Id = p.Id,
                Name = p.Name,
                Weight =  p.Weight,
                Warranty =  p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock =  p.Stock
            }).ToListAsync(cancellationToken);
    }

    public async Task<PcGetByIdDto> GetComponentsAsync(int id, CancellationToken cancellationToken)
    {
        return await ctx.PCs.Where(pc => pc.Id == id).Select(
            p => new PcGetByIdDto
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock,
                Components = p.PCComponents.Select(pcComponent => new PcComponentDto
                {
                    Amount = pcComponent.Amount,
                    Component = new ComponentDto
                    {
                        Code = pcComponent.Component.Code,
                        Name = pcComponent.Component.Name,
                        Description = pcComponent.Component.Description,
                        Manufacturer = new ManufacturerDto
                        {
                            Id = pcComponent.Component.ComponentManufacturers.Id,
                            Abbreviation = pcComponent.Component.ComponentManufacturers.Abbreviation,
                            FullName = pcComponent.Component.ComponentManufacturers.FullName,
                            FoundationDate = pcComponent.Component.ComponentManufacturers.FoundationDate
                        },
                        Type = new ComponentTypeDto
                        {
                            Id = pcComponent.Component.ComponentTypes.Id,
                            Abbreviation = pcComponent.Component.ComponentTypes.Abbreviation,
                            Name = pcComponent.Component.ComponentTypes.Name
                        }
                    }
                }).ToList()
            }).FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException($"PC with id {id} not found");
    }

    public async Task<PcGetAllDto> AddAsync(PcCreateDto request, CancellationToken cancellationToken)
    {
        if (request.CreatedAt > DateTime.UtcNow)
            throw new BadRequestException("CreatedAt cannot be a future date.");

        if (request.Weight <= 0)
            throw new BadRequestException("Weight must be greater than 0.");

        if (request.Warranty <= 0)
            throw new BadRequestException("Warranty must be greater than 0.");

        if (request.Stock < 0)
            throw new BadRequestException("Stock cannot be negative.");

        bool nameExists = await ctx.PCs
            .AnyAsync(p => p.Name == request.Name, cancellationToken);

        if (nameExists)
            throw new BadRequestException($"PC with name '{request.Name}' already exists.");

        var pc = new PC
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };
        
        ctx.PCs.Add(pc);
        await ctx.SaveChangesAsync(cancellationToken);

        return new PcGetAllDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task UpdateAsync(int id, PcUpdateDto request, CancellationToken cancellationToken)
    {
        if (request.CreatedAt > DateTime.UtcNow)
            throw new BadRequestException("CreatedAt cannot be a future date.");

        if (request.Weight <= 0)
            throw new BadRequestException("Weight must be greater than 0.");

        if (request.Warranty <= 0)
            throw new BadRequestException("Warranty must be greater than 0.");

        if (request.Stock < 0)
            throw new BadRequestException("Stock cannot be negative.");

        bool nameTaken = await ctx.PCs
            .AnyAsync(p => p.Name == request.Name && p.Id != id, cancellationToken);

        if (nameTaken)
            throw new BadRequestException($"PC with name '{request.Name}' already exists.");

        int affectedRows = await ctx.PCs
            .Where(p => p.Id == id)
            .ExecuteUpdateAsync(setters => setters
                    .SetProperty(e => e.Name, request.Name)
                    .SetProperty(e => e.Weight, request.Weight)
                    .SetProperty(e => e.Warranty, request.Warranty)
                    .SetProperty(e => e.CreatedAt, request.CreatedAt)
                    .SetProperty(e => e.Stock, request.Stock),
                cancellationToken
            );

        if (affectedRows == 0)
            throw new NotFoundException($"PC with id {id} not found");
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        int affectedRows = await ctx.PCs
            .Where(p => p.Id == id)
            .ExecuteDeleteAsync(cancellationToken);

        if (affectedRows == 0)
            throw new NotFoundException($"PC with id {id} not found");
    }
}