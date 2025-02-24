using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestioneAzienda.Data.Vehicles;
using GestioneAzienda.Data;

namespace GestioneAzienda.Controllers.Vehicles
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleDocumentController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public VehicleDocumentController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: api/VehicleDocument
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDocument>>> GetVehicleDocuments()
        {
            try
            {
                var vehicleDocuments = await _context.VehicleDocuments.ToListAsync();
                return Ok(vehicleDocuments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET: api/VehicleDocument/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDocument>> GetVehicleDocument(int id)
        {
            try
            {
                var vehicleDocument = await _context.VehicleDocuments.FindAsync(id);

                if (vehicleDocument == null)
                {
                    return NotFound();
                }

                return Ok(vehicleDocument);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST: api/VehicleDocument
        [HttpPost]
        public async Task<ActionResult<VehicleDocument>> CreateVehicleDocument(VehicleDocument vehicleDocument)
        {
            try
            {
                _context.VehicleDocuments.Add(vehicleDocument);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetVehicleDocument), new { id = vehicleDocument.VehicleDocumentId }, vehicleDocument);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // PUT: api/VehicleDocument/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicleDocument(int id, VehicleDocument vehicleDocument)
        {
            if (id != vehicleDocument.VehicleDocumentId)
            {
                return BadRequest();
            }

            _context.Entry(vehicleDocument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleDocumentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, "Concurrency error occurred while updating the vehicle document.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }

            return Ok("Vehicle document updated successfully.");
        }

        // DELETE: api/VehicleDocument/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleDocument(int id)
        {
            try
            {
                var vehicleDocument = await _context.VehicleDocuments.FindAsync(id);
                if (vehicleDocument == null)
                {
                    return NotFound();
                }

                _context.VehicleDocuments.Remove(vehicleDocument);
                await _context.SaveChangesAsync();

                return Ok("Vehicle document deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        private bool VehicleDocumentExists(int id)
        {
            return _context.VehicleDocuments.Any(vd => vd.VehicleDocumentId == id);
        }
    }
}
