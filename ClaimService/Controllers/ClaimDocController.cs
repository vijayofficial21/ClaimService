using ClaimService_Application.DTO;
using ClaimService_Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace service.Controllers
{
    [Route("claimdoc")]
    [ApiController]
    public class ClaimDocController : ControllerBase
    {
        private readonly IClaimDocService service;
        public ClaimDocController(IClaimDocService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 5)
        {
            return Ok(await service.GetAllAsync(pageNumber,pageSize));
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetDocById(int id)
        {
            var doc = await service.GetByIdAsync(id);
            if(doc == null)
            {
                return NotFound();
            }
            return Ok(doc);

        }

        [HttpPost]

        public async Task<IActionResult> CreateDocClaim(CreateClaimDocDto dto)
        {
            var result = await service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { id = result.ClaimDocId }, result);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id , UpdateClaimDocDto dto)
        {
            var result = await service.UpdateAsync(id, dto);

            if(!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();

        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] UploadClaimDocDto dto)
        {
            var result = await service.UploadAsync(dto);
            return Ok(result);
        }


    }
}
