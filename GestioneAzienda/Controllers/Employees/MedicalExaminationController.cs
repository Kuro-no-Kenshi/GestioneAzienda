using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestioneAzienda.Data;
using GestioneAzienda.Data.Employees;

namespace GestioneAzienda.Controllers.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalExaminationController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public MedicalExaminationController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: api/MedicalExamination
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalExamination>>> GetMedicalExaminations()
        {
            return await _context.MedicalExaminations.ToListAsync();
        }

        // GET: api/MedicalExamination/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalExamination>> GetMedicalExamination(int id)
        {
            var medicalExamination = await _context.MedicalExaminations.FindAsync(id);

            if (medicalExamination == null)
            {
                return NotFound();
            }

            return medicalExamination;
        }

        // POST: api/MedicalExamination
        [HttpPost]
        public async Task<ActionResult<MedicalExamination>> CreateMedicalExamination(MedicalExamination medicalExamination)
        {
            _context.MedicalExaminations.Add(medicalExamination);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMedicalExamination), new { id = medicalExamination.MedicalExaminationId }, medicalExamination);
        }

        // PUT: api/MedicalExamination/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicalExamination(int id, MedicalExamination medicalExamination)
        {
            if (id != medicalExamination.MedicalExaminationId)
            {
                return BadRequest();
            }

            _context.Entry(medicalExamination).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalExaminationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, "Concurrency error occurred while updating the medical examination.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }

            return Ok("Medical examination updated successfully.");
        }



        // DELETE: api/MedicalExamination/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalExamination(int id)
        {
            var medicalExamination = await _context.MedicalExaminations.FindAsync(id);
            if (medicalExamination == null)
            {
                return NotFound();
            }

            _context.MedicalExaminations.Remove(medicalExamination);
            await _context.SaveChangesAsync();

            return Ok("Medical examination deleted successfully.");
        }

        private bool MedicalExaminationExists(int id)
        {
            return _context.MedicalExaminations.Any(me => me.MedicalExaminationId == id);
        }
    }
}
