using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimService_Domain.Models
{
    public class Claims
    {
        [Key]
        public int ClaimId { get; set; }
        public int PolicyId { get; set; }

        public decimal ClaimAmount { get; set; }

        public string Status { get; set; }
        public string Description { get; set; }

        //Audit Feilds 
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
