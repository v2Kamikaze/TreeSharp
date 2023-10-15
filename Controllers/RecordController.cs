using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TreeSharp.Database;
using TreeSharp.Models;
using TreeSharp.Models.DTO;

namespace TreeSharp.Controllers;

[ApiController]
[Route("api")]
public class RecordController : ControllerBase
{
    [HttpGet("v1/record/{id}")]
    public async Task<IActionResult> GetRecord([FromServices] AppDbContext dbContext, [FromRoute] int id)
    {
        try
        {
            var record = await dbContext.Records.FirstOrDefaultAsync(x => x.Id == id);
            if (record == null) return NoContent();
            return Ok(record);
        }
        catch (DbException)
        {
            return BadRequest();
        }
    }


    [HttpGet("v1/record")]
    public async Task<IActionResult> GetRecords([FromServices] AppDbContext dbContext)
    {
        try
        {
            var records = await dbContext.Records.ToListAsync();
            return Ok(records);
        }
        catch (DbException)
        {
            return BadRequest();
        }
    }


    [HttpPost("v1/record")]
    public async Task<IActionResult> AddRecord([FromServices] AppDbContext dbContext, [FromBody] RecordDTO inputRecord)
    {
        try
        {
            var record = new Record { Parent = inputRecord.Parent };

            await dbContext.Records.AddAsync(record);
            await dbContext.SaveChangesAsync();
            return Created("", record);

        }
        catch (DbUpdateException)
        {
            return BadRequest();
        }
    }


    [HttpDelete("v1/record")]
    public async Task<IActionResult> DeleteRecord([FromServices] AppDbContext dbContext, [FromQuery] int id)
    {
        try
        {
            var record = await dbContext.Records.FirstOrDefaultAsync(x => x.Id == id);
            if (record == null) return NotFound();

            dbContext.Records.Remove(record);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }
        catch (DbUpdateException)
        {
            return BadRequest();
        }
    }


    [HttpPut("v1/record")]
    public async Task<IActionResult> UpdateRecord([FromServices] AppDbContext dbContext, [FromQuery] int id, [FromBody] RecordDTO inputRecord)
    {
        try
        {
            var record = await dbContext.Records.FirstOrDefaultAsync(x => x.Id == id);
            if (record == null) return NotFound();

            record.Parent = inputRecord.Parent;

            dbContext.Records.Update(record);
            await dbContext.SaveChangesAsync();

            return Ok();
        }
        catch (DbUpdateException)
        {
            return BadRequest();
        }
    }

}