using ClaimService_Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimService_Application.Interface
{
    public interface IClaimDocService
    {
        Task<ClaimDocDto> CreateAsync(CreateClaimDocDto dto);

        Task<bool> UpdateAsync(int id, UpdateClaimDocDto dto);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<ClaimDocDto>> GetAllAsync();

        Task<ClaimDocDto> GetByIdAsync(int id);

    }
}
