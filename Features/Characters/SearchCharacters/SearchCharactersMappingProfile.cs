using AutoMapper;
using Infrastructure.RickandMortyAPI.Characters;


namespace Features.Characters.GetSuggestions
{
    public class SearchCharactersMappingProfile : Profile
    {
        public SearchCharactersMappingProfile()
        {
            CreateMap<CharacterDto, SearchCharacterDto>()
                .ForMember(destiny => destiny.Id, option => option.MapFrom(src => src.Id))
                .ForMember(destiny => destiny.Name, option => option.MapFrom(src => src.Name))
            ;
        }
    }
}