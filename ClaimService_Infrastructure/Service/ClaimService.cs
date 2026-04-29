using AutoMapper;
using ClaimService_Application.DTO;
using ClaimService_Application.Interface;
using ClaimService_Application.Wrapper;
using ClaimService_Domain.Models;
using ClaimService_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClaimService_Infrastructure.Service
{
    public class ClaimService : IClaimService
    {
        public readonly ApplicationDbContext db;

        public readonly IMapper mapper;
        public ClaimService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;

        }
        public async Task<ClaimDto> CreateClaims(CreateClaimDto dto)
        {
            var claim = mapper.Map<Claims>(dto);

            claim.CreatedBy = "Admin";
            claim.CreatedAt = DateTime.UtcNow;
            claim.Status = "Pending";

            db.Claims.Add(claim);
            await db.SaveChangesAsync();

            return mapper.Map<ClaimDto>(claim);
        }
        public async Task<bool> UpdateClaims(int id, UpdateClaimDto dto)
        {
            var claim = await db.Claims.FindAsync(id);
            if (claim == null)
            {
                return false;
            }
            mapper.Map(dto, claim);

            claim.UpdatedAt = DateTime.UtcNow;

            await db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteClaims(int id)
        {
            var claim = await db.Claims.FindAsync(id);

            if (claim == null)
            {
                return false;
            }

            db.Claims.Remove(claim);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<PagedResponse<ClaimDto>> GetAllClaims(int pageNumber , int pageSize)
        {

            var TotalRecords = await db.Claims.CountAsync();


            var claims = await db.Claims
                .Skip((pageNumber-1)* pageSize)
                .Take(pageSize)
                .ToListAsync();

            if (pageNumber <= 0)
            {
                pageNumber = 1;
            }

            if (pageSize <= 0)
            {
                pageSize = 5;
            }

            var data =  mapper.Map<List<ClaimDto>>(claims);

            return PagedResponse<ClaimDto>.Create(data, pageNumber, pageSize, TotalRecords);

            
        }

        public async Task<ClaimDto> GetClaimsById(int id)
        {
            var claim = await db.Claims.FindAsync(id);
            return claim == null ? null : mapper.Map<ClaimDto>(claim);
        }

        public async Task<IEnumerable<ClaimDto>> GetByPolicyIdAsync(int PolicyId)
        {
            var claims = await db.Claims
                 .Where(x => x.PolicyId == PolicyId)
                 .ToListAsync();
            return mapper.Map<IEnumerable<ClaimDto>>(claims);

        }


        public async Task<bool> ApproveClaimAsync(int id)
        {
            var claim = await db.Claims.FindAsync(id);

            if(claim == null)
            {
                return false;

            }
            claim.Status = "Approved";
            claim.UpdatedAt = DateTime.UtcNow;

            await db.SaveChangesAsync();
            return true;

        }

        public async Task<bool> RejectClaimAsync(int id)
        {
            var claim = await db.Claims.FindAsync(id);

            if (claim == null)
            {
                return false;
            }
               

            claim.Status = "Rejected";
            claim.UpdatedAt = DateTime.UtcNow;

            await db.SaveChangesAsync();

            return true;
        }

       
    }
}
