using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimService_Application.DTO
{
    public class CreateClaimDocDto
    {
        public int ClaimId { get; set; }
        public string DocumentPath { get; set; }
        public string DocumentName { get; set; }
    }
}
