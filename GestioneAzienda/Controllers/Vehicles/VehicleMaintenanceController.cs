using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestioneAzienda.Data;
using GestioneAzienda.Data.Vehicles;

namespace GestioneAzienda.Controllers.Vehicles
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMaintenanceController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public VehicleMaintenanceController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: api/VehicleMaintenance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleMaintenance>>> GetVehicleMaintenances()
        {
            try
            {
                var maintenances = await _context.VehicleMaintenances.ToListAsync();
                return Ok(maintenances);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET: api/VehicleMaintenance/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleMaintenance>> GetVehicleMaintenance(int id)
        {
            try
            {
                var maintenance = await _context.VehicleMaintenances.FindAsync(id);

                if (maintenance == null)
                {
                    return NotFound($"Vehicle Maintenance with ID {id} not found.");
                }

                return Ok(maintenance);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST: api/VehicleMaintenance
        [HttpPost]
        public async Task<ActionResult<VehicleMaintenance>> CreateVehicleMaintenance(VehicleMaintenance maintenance)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.VehicleMaintenances.Add(maintenance);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetVehicleMaintenance), new { id = maintenance.VehicleMaintenanceId }, maintenance);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // PUT: api/VehicleMaintenance/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicleMaintenance(int id, VehicleMaintenance maintenance)
        {
            if (id != maintenance.VehicleMaintenanceId)
            {
                return BadRequest("Vehicle Maintenance ID mismatch.");
            }

            try
            {
                var existingMaintenance = await _context.VehicleMaintenances.FindAsync(id);

                if (existingMaintenance == null)
                {
                    return NotFound($"Vehicle Maintenance with ID {id} not found.");
                }

                _context.Entry(existingMaintenance).CurrentValues.SetValues(maintenance);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Concurrency error occurred while updating the maintenance.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // DELETE: api/VehicleMaintenance/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleMaintenance(int id)
        {
            try
            {
                var maintenance = await _context.VehicleMaintenances.FindAsync(id);

                if (maintenance == null)
                {
                    return NotFound($"Vehicle Maintenance with ID {id} not found.");
                }

                _context.VehicleMaintenances.Remove(maintenance);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        private bool VehicleMaintenanceExists(int id)
        {
            return _context.VehicleMaintenances.Any(m => m.VehicleMaintenanceId == id);
        }
    }
}
