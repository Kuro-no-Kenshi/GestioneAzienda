using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestioneAzienda.Data.Employees;
using GestioneAzienda.Data;

namespace GestioneAzienda.Controllers.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalLevelController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public ProfessionalLevelController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: api/ProfessionalLevel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessionalLevel>>> GetProfessionalLevels()
        {
            try
            {
                return await _context.ProfessionalLevels.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET: api/ProfessionalLevel/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfessionalLevel>> GetProfessionalLevel(int id)
        {
            try
            {
                var professionalLevel = await _context.ProfessionalLevels.FindAsync(id);

                if (professionalLevel == null)
                {
                    return NotFound();
                }

                return professionalLevel;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST: api/ProfessionalLevel
        [HttpPost]
        public async Task<ActionResult<ProfessionalLevel>> CreateProfessionalLevel(ProfessionalLevel professionalLevel)
        {
            try
            {
                _context.ProfessionalLevels.Add(professionalLevel);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetProfessionalLevel), new { id = professionalLevel.ProfessionalLevelId }, professionalLevel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // PUT: api/ProfessionalLevel/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfessionalLevel(int id, ProfessionalLevel professionalLevel)
        {
            if (id != professionalLevel.ProfessionalLevelId)
            {
                return BadRequest();
            }

            _context.Entry(professionalLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessionalLevelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, "Concurrency error occurred while updating the professional level.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }

            return NoContent();
        }

        // DELETE: api/ProfessionalLevel/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessionalLevel(int id)
        {
            try
            {
                var professionalLevel = await _context.ProfessionalLevels.FindAsync(id);
                if (professionalLevel == null)
                {
                    return NotFound();
                }

                _context.ProfessionalLevels.Remove(professionalLevel);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        private bool ProfessionalLevelExists(int id)
        {
            return _context.ProfessionalLevels.Any(pl => pl.ProfessionalLevelId == id);
        }
    }
}
