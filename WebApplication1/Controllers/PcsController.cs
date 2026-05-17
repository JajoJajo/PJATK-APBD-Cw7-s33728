using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/pcs")]
public class PcsController(IPcService pcService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await pcService.GetAllAsync(cancellationToken);
        return Ok(result);
    }
    
    [HttpGet("{id}/components")]
    public async Task<IActionResult> GetComponents([FromRoute]int id, CancellationToken cancellationToken)
    {
        try
        {
            var result = await pcService.GetComponentsAsync(id, cancellationToken);
            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return NotFound(new { error = e.Message });
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PcCreateDto dto, CancellationToken cancellationToken)
    {
        try
        {
            var created = await pcService.AddAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
        }
        catch (BadRequestException e)
        {
            return BadRequest(new { error = e.Message });
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PcUpdateDto dto, CancellationToken cancellationToken)
    {
        try
        {
            await pcService.UpdateAsync(id, dto, cancellationToken);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(new { error = e.Message });
        }
        catch (BadRequestException e)
        {
            return BadRequest(new { error = e.Message });
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        try
        {
            await pcService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(new { error = e.Message });
        }
    }
}