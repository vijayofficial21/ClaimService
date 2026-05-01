using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClaimService_Application.DTO
{
    public class PolicyClient
    {
        HttpClient client;
        public PolicyClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<PolicyDTO> GetbyId(int id)
        {
            return await client.GetFromJsonAsync<PolicyDTO>($"policy/{id}");
        }

    }
}
