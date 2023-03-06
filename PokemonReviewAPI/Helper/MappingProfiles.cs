using AutoMapper;
using PokemonReviewAPI.Dto;
using PokemonReviewAPI.Models;

namespace PokemonReviewAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Country, CountryDto>();
        }
    }
}
