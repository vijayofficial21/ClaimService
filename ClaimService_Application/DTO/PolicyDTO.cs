using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimService_Application.DTO
{
    public class PolicyDTO
    {
        public int Policy_Id { get; set; }

        public string PolicyType_Name { get; set; }

        public string Policy_Description { get; set; }
    }
}
