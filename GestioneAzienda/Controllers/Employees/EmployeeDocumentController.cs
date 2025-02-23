using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestioneAzienda.Data.Employees;
using GestioneAzienda.Data;

namespace GestioneAzienda.Controllers.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDocumentController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public EmployeeDocumentController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeDocument
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDocument>>> GetEmployeeDocuments()
        {
            try
            {
                return await _context.EmployeeDocuments.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET: api/EmployeeDocument/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDocument>> GetEmployeeDocument(int id)
        {
            try
            {
                var document = await _context.EmployeeDocuments.FindAsync(id);

                if (document == null)
                {
                    return NotFound();
                }

                return document;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST: api/EmployeeDocument
        [HttpPost]
        public async Task<ActionResult<EmployeeDocument>> CreateEmployeeDocument(EmployeeDocument document)
        {
            try
            {
                _context.EmployeeDocuments.Add(document);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetEmployeeDocument), new { id = document.EmployeeDocumentId }, document);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // PUT: api/EmployeeDocument/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeDocument(int id, EmployeeDocument document)
        {
            if (id != document.EmployeeDocumentId)
            {
                return BadRequest();
            }

            _context.Entry(document).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDocumentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, "Concurrency error occurred while updating the employee document.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }

            return NoContent();
        }

        // DELETE: api/EmployeeDocument/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeDocument(int id)
        {
            try
            {
                var document = await _context.EmployeeDocuments.FindAsync(id);
                if (document == null)
                {
                    return NotFound();
                }

                _context.EmployeeDocuments.Remove(document);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        private bool EmployeeDocumentExists(int id)
        {
            return _context.EmployeeDocuments.Any(e => e.EmployeeDocumentId == id);
        }
    }
}
