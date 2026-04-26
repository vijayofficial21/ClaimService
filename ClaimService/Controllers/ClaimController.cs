using ClaimService_Application.DTO;
using ClaimService_Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        public readonly IClaimService service;

        public ClaimController(IClaimService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClaimDto dto)
        {
            var result = await service.CreateClaims(dto);
            return CreatedAtAction(nameof(Get), new { id = result.ClaimId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateClaimDto dto)
        {
            var updated = await service.UpdateClaims(id, dto);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.DeleteClaims(id);
            if (!deleted)
            {
                return NotFound();
            }
            
            return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllClaims());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var claim = await service.GetClaimsById(id);
            if (claim == null) return NotFound();

            return Ok(claim);
        }
    }
}
