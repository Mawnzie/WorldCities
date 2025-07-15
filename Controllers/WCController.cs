using Microsoft.AspNetCore.Mvc;
using WorldCities.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
namespace WorldCities.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WCController : ControllerBase
{
    private readonly WCContext _context;

    public WCController(WCContext context)
    {
        _context = context;
    }



    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorldCity>>> GetWorldCities()
    {
        var cities = await _context.WorldCities
            .OrderByDescending(c => c.Population)
            .ToListAsync();

        return Ok(cities);
    }


    [HttpGet("{CityId}")]
    public async Task<ActionResult<WorldCity>> GetWorldCity(int CityId)
    {
        var city = await _context.WorldCities.FindAsync(CityId);

        if (city == null)
        {
            return NotFound();
        }
        return city;
    }

    [HttpPut("{CityId}")]
    public async Task<IActionResult> PutWorldCity(int id, WorldCity city)
    {
        if (id != city.CityId)
        {
            return BadRequest();
        }
        _context.Entry(city).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!WorldCityExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<WorldCity>> PostWorldCity(WorldCity city)
    {
        _context.WorldCities.Add(city);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetWorldCity", new { CityId = city.CityId }, city);
    }
    [HttpDelete("{CityId}")]
    public async Task<IActionResult> DeleteWorldCity(int CityId)
    {
        var city = await _context.WorldCities.FindAsync(CityId);
        if (city == null)
        {
            return NotFound();
        }
        _context.WorldCities.Remove(city);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool WorldCityExists(int CityId)
{
    return _context.WorldCities.Any(e => e.CityId == CityId);
}

}