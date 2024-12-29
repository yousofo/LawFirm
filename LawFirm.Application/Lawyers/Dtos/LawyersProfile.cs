using AutoMapper;
using LawFirm.Domain.Entities;

namespace LawFirm.Application.Lawyers.Dtos
{
    public class LawyersProfile : Profile
    {
        public LawyersProfile()
        {
            CreateMap<Lawyer, LawyerDto>().ForMember(
                dest => dest.City,
                opt => opt.MapFrom(src => src.Address == null ? null : src.Address.City)
            );

            CreateMap<LawyerDto, Lawyer>();
        }
    }
}
