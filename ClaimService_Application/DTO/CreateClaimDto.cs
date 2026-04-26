using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimService_Application.DTO
{
    public class CreateClaimDto
    {
        public int PolicyId { get; set; }
        public decimal ClaimAmount { get; set; }
        public string Description { get; set; }
    }
}
