using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestioneAzienda.Data.Vehicles;
using GestioneAzienda.Data;

namespace GestioneAzienda.Controllers.Vehicles
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public VehicleController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: api/Vehicle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        {
            try
            {
                var vehicles = await _context.Vehicles
                    .Include(v => v.Document)
                    .Include(v => v.Maintenance)
                    .ToListAsync();

                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET: api/Vehicle/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            try
            {
                var vehicle = await _context.Vehicles
                    .Include(v => v.Document)
                    .Include(v => v.Maintenance)
                    .FirstOrDefaultAsync(v => v.VehicleId == id);

                if (vehicle == null)
                {
                    return NotFound($"Vehicle with ID {id} not found.");
                }

                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST: api/Vehicle
        [HttpPost]
        public async Task<ActionResult<Vehicle>> CreateVehicle(Vehicle vehicle)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Vehicles.Add(vehicle);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetVehicle), new { id = vehicle.VehicleId }, vehicle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // PUT: api/Vehicle/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.VehicleId)
            {
                return BadRequest("Vehicle ID mismatch.");
            }

            try
            {
                var existingVehicle = await _context.Vehicles
                    .Include(v => v.Document)
                    .Include(v => v.Maintenance)
                    .FirstOrDefaultAsync(v => v.VehicleId == id);

                if (existingVehicle == null)
                {
                    return NotFound($"Vehicle with ID {id} not found.");
                }

                _context.Entry(existingVehicle).CurrentValues.SetValues(vehicle);

                // Aggiorna le liste di documenti e manutenzioni
                existingVehicle.Document = vehicle.Document;
                existingVehicle.Maintenance = vehicle.Maintenance;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Concurrency error occurred while updating the vehicle.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // DELETE: api/Vehicle/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            try
            {
                var vehicle = await _context.Vehicles
                    .Include(v => v.Document)
                    .Include(v => v.Maintenance)
                    .FirstOrDefaultAsync(v => v.VehicleId == id);

                if (vehicle == null)
                {
                    return NotFound($"Vehicle with ID {id} not found.");
                }

                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(v => v.VehicleId == id);
        }
    }
}
