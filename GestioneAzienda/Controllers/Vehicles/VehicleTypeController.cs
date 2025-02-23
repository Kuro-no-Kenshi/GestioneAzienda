using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestioneAzienda.Data.Vehicles;
using GestioneAzienda.Data;

namespace GestioneAzienda.Controllers.Vehicles
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypeController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public VehicleTypeController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: api/VehicleType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleType>>> GetVehicleTypes()
        {
            try
            {
                var vehicleTypes = await _context.VehicleTypes.ToListAsync();
                return Ok(vehicleTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET: api/VehicleType/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleType>> GetVehicleType(int id)
        {
            try
            {
                var vehicleType = await _context.VehicleTypes.FindAsync(id);

                if (vehicleType == null)
                {
                    return NotFound();
                }

                return Ok(vehicleType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST: api/VehicleType
        [HttpPost]
        public async Task<ActionResult<VehicleType>> CreateVehicleType(VehicleType vehicleType)
        {
            try
            {
                _context.VehicleTypes.Add(vehicleType);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetVehicleType), new { id = vehicleType.VehicleTypeId }, vehicleType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // PUT: api/VehicleType/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicleType(int id, VehicleType vehicleType)
        {
            if (id != vehicleType.VehicleTypeId)
            {
                return BadRequest("Vehicle type ID mismatch.");
            }

            _context.Entry(vehicleType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, "Concurrency error occurred while updating the vehicle type.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }

            return NoContent();
        }

        // DELETE: api/VehicleType/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleType(int id)
        {
            try
            {
                var vehicleType = await _context.VehicleTypes.FindAsync(id);
                if (vehicleType == null)
                {
                    return NotFound();
                }

                _context.VehicleTypes.Remove(vehicleType);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        private bool VehicleTypeExists(int id)
        {
            return _context.VehicleTypes.Any(vt => vt.VehicleTypeId == id);
        }
    }
}
