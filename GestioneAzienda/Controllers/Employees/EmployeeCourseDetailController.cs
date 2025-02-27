using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestioneAzienda.Data;
using GestioneAzienda.Data.Employees;

namespace GestioneAzienda.Controllers.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeCourseDetailController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public EmployeeCourseDetailController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeCourseDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeCourseDetail>>> GetEmployeeCourses()
        {
            try
            {
                return await _context.EmployeeCourseDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET: api/EmployeeCourseDetail/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeCourseDetail>> GetEmployeeCourse(long id)
        {
            try
            {
                var employeeCourse = await _context.EmployeeCourseDetails.FindAsync(id);

                if (employeeCourse == null)
                {
                    return NotFound();
                }

                return employeeCourse;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST: api/EmployeeCourseDetail
        [HttpPost]
        public async Task<ActionResult<EmployeeCourseDetail>> CreateEmployeeCourse(EmployeeCourseDetail employeeCourse)
        {
            try
            {
                _context.EmployeeCourseDetails.Add(employeeCourse);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetEmployeeCourse), new { id = employeeCourse.EmployeeCourseDetailId }, employeeCourse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // PUT: api/EmployeeCourseDetail/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeCourse(long id, EmployeeCourseDetail employeeCourse)
        {
            if (id != employeeCourse.EmployeeCourseDetailId)
            {
                return BadRequest();
            }

            _context.Entry(employeeCourse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeCourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, "Concurrency error occurred while updating the employee course.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }

            return Ok("Employee course updated successfully.");
        }

        // DELETE: api/EmployeeCourseDetail/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeCourse(long id)
        {
            try
            {
                var employeeCourse = await _context.EmployeeCourseDetails.FindAsync(id);
                if (employeeCourse == null)
                {
                    return NotFound();
                }

                _context.EmployeeCourseDetails.Remove(employeeCourse);
                await _context.SaveChangesAsync();

                return Ok("Employee course deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        private bool EmployeeCourseExists(long id)
        {
            return _context.EmployeeCourseDetails.Any(ec => ec.EmployeeCourseDetailId == id);
        }
    }
}
