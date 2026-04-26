using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimService_Application.DTO
{
    public class ClaimDocDto
    {
        public int ClaimDocId { get; set; }
        public int ClaimId { get; set; }

        public string DocumentPath { get; set; }
        public string DocumentName { get; set; }
    }
}
