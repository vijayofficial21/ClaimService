using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimService_Application.DTO
{
    public class UpdateClaimDto
    {
        public decimal ClaimAmount { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
    }
}
