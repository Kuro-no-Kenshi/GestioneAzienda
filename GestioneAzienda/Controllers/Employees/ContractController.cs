using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestioneAzienda.Data;
using GestioneAzienda.Data.Employees;

namespace GestioneAzienda.Controllers.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public ContractController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: api/Contract
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contract>>> GetContracts()
        {
            try
            {
                var contracts = await _context.Contracts.ToListAsync();
                return Ok(contracts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET: api/Contract/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Contract>> GetContract(int id)
        {
            try
            {
                var contract = await _context.Contracts.FindAsync(id);

                if (contract == null)
                {
                    return NotFound($"Contract with ID {id} not found.");
                }

                return Ok(contract);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST: api/Contract
        [HttpPost]
        public async Task<ActionResult<Contract>> CreateContract(Contract contract)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Contracts.Add(contract);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetContract), new { id = contract.ContractId }, contract);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // PUT: api/Contract/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContract(int id, Contract contract)
        {
            if (id != contract.ContractId)
            {
                return BadRequest();
            }

            _context.Entry(contract).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, "Concurrency error occurred while updating the contract.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }

            return Ok("Contract updated successfully.");
        }


        // DELETE: api/Contract/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContract(int id)
        {
            try
            {
                var contract = await _context.Contracts.FindAsync(id);

                if (contract == null)
                {
                    return NotFound($"Contract with ID {id} not found.");
                }

                _context.Contracts.Remove(contract);
                await _context.SaveChangesAsync();

                return Ok("Contract deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        private bool ContractExists(int id)
        {
            return _context.Contracts.Any(c => c.ContractId == id);
        }
    }
}
