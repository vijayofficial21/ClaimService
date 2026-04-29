using ClaimService_Application.DTO;
using ClaimService_Application.Wrapper;
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
        Task<PagedResponse<ClaimDto>> GetAllClaims(int pageNumber, int pageSize);
        Task<ClaimDto> GetClaimsById(int id);


        Task<IEnumerable<ClaimDto>> GetByPolicyIdAsync(int PolicyId);
        Task<bool> ApproveClaimAsync(int id);

        Task<bool> RejectClaimAsync(int id);


    }
}
