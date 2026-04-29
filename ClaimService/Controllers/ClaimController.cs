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
            return CreatedAtAction(nameof(GetById), new { id = result.ClaimId }, result);
        }

        [HttpPut("Update/{id}")]
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
        public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 5)
        {
            return Ok(await service.GetAllClaims(pageNumber,pageSize));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var claim = await service.GetClaimsById(id);
            if (claim == null) return NotFound();

            return Ok(claim);
        }




        [HttpGet("Policy/{PolicyId}")]
        public async Task<IActionResult> GetByPolicy(int PolicyId)
        {
            var claims = await service.GetByPolicyIdAsync(PolicyId);
            return Ok(claims);
        }


        [HttpPut("Approve/{id}")]

        public async Task<IActionResult> ApproveClaim(int id)
        {
            var result = await service.ApproveClaimAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("Reject/{id}")]

        public async Task<IActionResult> RejectClaim(int id)
        {
            var result = await service.RejectClaimAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        //[HttpGet("test-error")]
        //public IActionResult TestError()
        //{
        //    throw new Exception("Test error");
        //}


    }
}
