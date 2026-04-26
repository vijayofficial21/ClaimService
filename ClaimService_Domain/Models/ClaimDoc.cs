using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimService_Domain.Models
{
    public class ClaimDoc
    {
        [Key]
        public int ClaimDocId { get; set; }

        [ForeignKey("claims")]
        public int ClaimId { get; set; }
        
        public string DocumentPath { get; set; }
        public string DocumentName { get; set; }

        //navigation property 

        public Claims claims { get; set; }


        //Audit Feilds 
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

