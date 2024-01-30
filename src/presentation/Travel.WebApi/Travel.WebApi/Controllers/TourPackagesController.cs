using Microsoft.AspNetCore.Mvc;
using Travel.Data.Contexts;
using Travel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Travel.WebApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TourPackagesController(TravelDbContext _context) : ControllerBase
    {
        private TravelDbContext _context = _context;

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.TourPackages);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TourPackage tourPackage)
        {
            try
            {
                await _context.TourPackages.AddAsync(tourPackage);
                await _context.SaveChangesAsync();

                return Ok(tourPackage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var tourPackage = await _context.TourPackages.SingleOrDefaultAsync(tp => tp.Id == id);

            if (tourPackage == null)
            {
                return NotFound();
            }

            _context.TourPackages.Remove(tourPackage);
            await _context.SaveChangesAsync();

            return Ok(tourPackage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TourPackage tourPackage)
        {
            _context.Update(tourPackage);

            await _context.SaveChangesAsync();

            return Ok(tourPackage);
        }
    }
}
