using ClaimService_Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimService_Application.Interface
{
    public interface IClaimService
    {
        
        Task<ClaimDto> CreateClaims(CreateClaimDto dto);
        Task<bool> UpdateClaims(int id, UpdateClaimDto dto);
        Task<bool> DeleteClaims(int id);
        Task<IEnumerable<ClaimDto>> GetAllClaims();
        Task<ClaimDto> GetClaimsById(int id);
    }
}
