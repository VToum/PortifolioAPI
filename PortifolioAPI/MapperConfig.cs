using AutoMapper;
using PortifolioAPI.Models;
using PortifolioAPI.Models.Dto;


namespace PortifolioAPI
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Contact, ContactDto>().ReverseMap();
        }
    }
}
