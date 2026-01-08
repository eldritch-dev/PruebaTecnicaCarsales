using AutoMapper;
using Infrastructure.RickandMortyAPI.Characters;


namespace Features.Characters.GetCharacters
{
    public class GetCharactersMappingProfile : Profile
    {
        public GetCharactersMappingProfile()
        {
            CreateMap<CharacterDto, GetCharactersResponse>()
                .ForMember(destiny => destiny.Id, option => option.MapFrom(src => src.Id))
                .ForMember(destiny => destiny.Name, option => option.MapFrom(src => src.Name))
                .ForMember(destiny => destiny.Species, option => option.MapFrom(src => src.Species))
                .ForMember(destiny => destiny.Gender, option => option.MapFrom(src => src.Gender))
                .ForMember(destiny => destiny.Origin, option => option.MapFrom(src => src.Origin))
                .ForMember(destiny => destiny.Image, option => option.MapFrom(src => src.Image))
                .ForMember(destiny => destiny.Url, option => option.MapFrom(src => src.Url))
            ;
            CreateMap<OriginDto, Origin>();
        }
    }
}