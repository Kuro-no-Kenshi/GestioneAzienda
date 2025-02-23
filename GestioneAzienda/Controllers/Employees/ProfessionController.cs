using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestioneAzienda.Data.Employees;
using GestioneAzienda.Data;

namespace GestioneAzienda.Controllers.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public ProfessionController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: api/Profession
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profession>>> GetProfessions()
        {
            try
            {
                return await _context.Professions.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET: api/Profession/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Profession>> GetProfession(int id)
        {
            try
            {
                var profession = await _context.Professions.FindAsync(id);

                if (profession == null)
                {
                    return NotFound();
                }

                return profession;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST: api/Profession
        [HttpPost]
        public async Task<ActionResult<Profession>> CreateProfession(Profession profession)
        {
            try
            {
                _context.Professions.Add(profession);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetProfession), new { id = profession.ProfessionId }, profession);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // PUT: api/Profession/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfession(int id, Profession profession)
        {
            if (id != profession.ProfessionId)
            {
                return BadRequest();
            }

            _context.Entry(profession).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, "Concurrency error occurred while updating the profession.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }

            return NoContent();
        }

        // DELETE: api/Profession/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfession(int id)
        {
            try
            {
                var profession = await _context.Professions.FindAsync(id);
                if (profession == null)
                {
                    return NotFound();
                }

                _context.Professions.Remove(profession);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        private bool ProfessionExists(int id)
        {
            return _context.Professions.Any(p => p.ProfessionId == id);
        }
    }
}
