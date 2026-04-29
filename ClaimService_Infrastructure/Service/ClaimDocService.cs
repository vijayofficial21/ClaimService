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
                throw new Exception("Invalid ClaimId");

            }

            var docs = mapper.Map<ClaimDoc>(dto);

            await db.ClaimDocs.AddAsync(docs);
            await db.SaveChangesAsync();

            return mapper.Map<ClaimDocDto>(docs);
        }

        public async  Task<bool> DeleteAsync(int id)
        {
            var docs = await db.ClaimDocs.FindAsync(id);
            if(docs == null)
            {
                return false;
            }
            db.ClaimDocs.Remove(docs);
            await db.SaveChangesAsync();
            return true; 


        }
        public async Task<bool> UpdateAsync(int id, UpdateClaimDocDto dto)
        {
            var docs = await db.ClaimDocs.FindAsync(id);
            if (docs == null)
            {
                return false;
            }
            mapper.Map(dto, docs);
            await db.SaveChangesAsync();
            return true;


        }

        public async  Task<PagedResponse<ClaimDocDto>> GetAllAsync(int pageNumber ,int pageSize)
        {

            var TotalRecords = await db.ClaimDocs.CountAsync();

            var docs = await db.ClaimDocs
                .Skip((pageNumber-1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            if (pageNumber<=0)
            {
                pageNumber = 1;
            }
            if (pageSize<=0)
            {
                pageSize = 5;
            }
           var data =  mapper.Map <List<ClaimDocDto>>(docs);

            return PagedResponse<ClaimDocDto>.Create(data, pageNumber, pageSize, TotalRecords);


        }

        public async Task<ClaimDocDto> GetByIdAsync(int id)
        {
            var docs = await db.ClaimDocs.FindAsync(id);
            return docs == null ? null : mapper.Map<ClaimDocDto>(docs);

        }

        public async Task<ClaimDocDto> UploadAsync(UploadClaimDocDto dto)
        {
            //Step 1 : Check if Claim exists 
            var claimexists = await db.Claims.AnyAsync(x => x.ClaimId == dto.ClaimId);
            if (!claimexists)
            {
                throw new Exception("Invalid ClaimId");
            }

            //step 2 : Check if file is provided
            if(dto.File == null || dto.File.Length == 0)
            {
                throw new Exception("file is required ");

            }

            //Step 3 : get file extension 

            var extension = Path.GetExtension(dto.File.FileName).ToLower();


            // Step 4: Allow only specific file types
            var allowedExtensions = new[] { ".pdf", ".jpg", ".png" };

            if (!allowedExtensions.Contains(extension))
            {
                throw new Exception("Invalid File type"); 
            }

            // Step 5: Create unique file name
            var fileName = Guid.NewGuid().ToString() + "_" + dto.File.FileName;

            // Step 6: Create folder path
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

            // Step 7: Create folder if not exists
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Step 8: Create full file path
            var filePath = Path.Combine(folderPath, fileName);

            // Step 9: Save file to server
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await dto.File.CopyToAsync(stream);
            }

            // Step 10: Save data in database
            var claimDoc = new ClaimDoc
            {
                ClaimId = dto.ClaimId,
                DocumentName = dto.File.FileName,
                DocumentPath = "/uploads/" + fileName,
                 CreatedBy = "System", 
                CreatedAt = DateTime.UtcNow
            };

            db.ClaimDocs.Add(claimDoc);
            await db.SaveChangesAsync();

            // Step 11: Return response
            return mapper.Map<ClaimDocDto>(claimDoc);


        }
    }
}
