using AutoMapper;
using Infrastructure.RickandMortyAPI.Characters;


namespace Features.Characters.GetCharacters
{
    public class GetCharactersMappingProfile : Profile
    {
        public GetCharactersMappingProfile()
        {
            CreateMap<CharacterDto, GetCharacterResponse>()
                .ForMember(destiny => destiny.Id, option => option.MapFrom(src => src.Id))
                .ForMember(destiny => destiny.Name, option => option.MapFrom(src => src.Name))
                .ForMember(destiny => destiny.Species, option => option.MapFrom(src => src.Species))
                .ForMember(destiny => destiny.Gender, option => option.MapFrom(src => src.Gender))
                .ForMember(destiny => destiny.Origin, option => option.MapFrom(src => src.Origin))
                .ForMember(destiny => destiny.Image, option => option.MapFrom(src => src.Image))
                .ForMember(destiny => destiny.Url, option => option.MapFrom(src => src.Url))
            ;
            CreateMap<OriginDto, Origin>();
            CreateMap<CharactersDto, GetCharactersResponse>()
                .ForMember(destiny => destiny.Characters, option => option.MapFrom(src => src.Results))
                .ForMember(destiny => destiny.TotalCharacters, option => option.MapFrom(src => src.Info.Count))
                .ForMember(destiny => destiny.TotalPages, option => option.MapFrom(src => src.Info.Pages))
                .ForMember(destiny => destiny.NextPageUrl, option => option.MapFrom(src => src.Info.Next))
                .ForMember(destiny => destiny.PreviousPageUrl, option => option.MapFrom(src => src.Info.Prev))
                .AfterMap((src, dest, ctx) =>
                {
                    dest.ActualPage = (int)ctx.Items["Page"];
                })
            ;
        }
    }
}