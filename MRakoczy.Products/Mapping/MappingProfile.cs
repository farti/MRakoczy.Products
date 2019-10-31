using AutoMapper;
using MRakoczy.Application.Models.Domain;
using MRakoczy.Application.Models.Dto;

namespace MRakoczy.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to API resource
            CreateMap<Product, ProductDto>();

            //API Resource to Domain
            CreateMap<ProductDto, Product>()
                .ForMember(p=>p.Id, opt => opt.Ignore());
        }
    }
}
