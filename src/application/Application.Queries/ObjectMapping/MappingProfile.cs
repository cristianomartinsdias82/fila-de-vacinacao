using Application.Queries.GetVaccinationQueue;
using AutoMapper;
using Domain;

namespace Application.Queries.ObjectMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDto>();
        }
    }
}
