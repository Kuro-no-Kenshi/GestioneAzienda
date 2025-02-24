using Microsoft.AspNetCore.Mvc;
using GestioneAzienda.Data.Employees;
using GestioneAzienda.Data;
using Microsoft.EntityFrameworkCore;

namespace GestioneAzienda.Controllers.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public CourseController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: api/Course
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            try
            {
                return await _context.Courses.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Course/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            try
            {
                var course = await _context.Courses.FindAsync(id);

                if (course == null)
                {
                    return NotFound("Course not found.");
                }

                return course;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving course: {ex.Message}");
            }
        }

        // POST: api/Course
        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse(Course course)
        {
            try
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetCourse), new { id = course.CourseId }, course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating course: {ex.Message}");
            }
        }

        // PUT: api/Course/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest("Course ID mismatch.");
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Course updated successfully.");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound("Course not found.");
                }
                return StatusCode(500, "Error updating course due to concurrency issue.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating course: {ex.Message}");
            }
        }

        // DELETE: api/Course/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            try
            {
                var course = await _context.Courses.FindAsync(id);
                if (course == null)
                {
                    return NotFound("Course not found.");
                }

                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();

                return Ok("Course deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting course: {ex.Message}");
            }
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(c => c.CourseId == id);
        }
    }
}
