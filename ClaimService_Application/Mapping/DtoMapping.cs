using AutoMapper;
using ClaimService_Application.DTO;
using ClaimService_Domain.Models;


namespace ClaimService_Application.Mapping
{
    public class DtoMapping :Profile
    {
        public DtoMapping()
        {
            CreateMap<Claims, ClaimDto>().ReverseMap();

            CreateMap<Claims, CreateClaimDto>().ReverseMap();

            CreateMap<Claims, UpdateClaimDto>().ReverseMap();




            CreateMap<ClaimDoc, ClaimDocDto>().ReverseMap();

            CreateMap<ClaimDoc, CreateClaimDocDto>().ReverseMap();

            CreateMap<ClaimDoc, UpdateClaimDocDto>().ReverseMap();


        }
    }
}
