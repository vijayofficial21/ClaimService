using ClaimService_Application.DTO;
using ClaimService_Application.Wrapper;
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

        Task<PagedResponse<ClaimDocDto>> GetAllAsync(int pageNumber, int pageSize);

        Task<ClaimDocDto> GetByIdAsync(int id);

        Task<ClaimDocDto> UploadAsync(UploadClaimDocDto dto); 

    }
}
