using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimService_Application.DTO
{
    public class UploadClaimDocDto
    {
        public int ClaimId { get; set; }

        public IFormFile File { get; set; }
    }
}
