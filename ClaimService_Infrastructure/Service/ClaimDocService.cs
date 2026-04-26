using AutoMapper;
using ClaimService_Application.DTO;
using ClaimService_Application.Interface;
using ClaimService_Domain.Models;
using ClaimService_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimService_Infrastructure.Service
{
    public class ClaimDocService : IClaimDocService
    {
        public readonly ApplicationDbContext db;

        public readonly IMapper mapper; 
        public ClaimDocService(ApplicationDbContext db , IMapper mapper)
        {
            this.db = db; 
            this.mapper = mapper;
        }

        public async Task<ClaimDocDto> CreateAsync(CreateClaimDocDto dto)
        {
            var claimExists = await db.Claims.AnyAsync(x => x.ClaimId == dto.ClaimId);
            if (!claimExists)
            {
                throw new Exception("Invalid ClaimId")
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async  Task<IEnumerable<ClaimDocDto>> GetAllAsync()
        {
            var docs = await db.ClaimDocs.ToListAsync();
            return mapper.Map <IEnumerable<ClaimDocDto>>(docs);
        }

        public async Task<ClaimDocDto> GetByIdAsync(int id)
        {
            var docs = await db.ClaimDocs.FindAsync(id);
            return docs == null ? null : mapper.Map<ClaimDocDto>(docs);

        }

        public Task<bool> UpdateAsync(int id, UpdateClaimDocDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
