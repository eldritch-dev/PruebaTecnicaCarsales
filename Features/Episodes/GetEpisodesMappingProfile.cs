using AutoMapper;
using Infrastructure.RickandMortyAPI.Episodes;


namespace Features.Episodes.GetEpisodes
{
    public class GetEpisodesMappingProfile : Profile
    {
        public GetEpisodesMappingProfile()
        {
            CreateMap<EpisodeDto, GetEpisodesResponse>()
                .ForMember(destiny => destiny.Id, option => option.MapFrom(src => src.Id))
                .ForMember(destiny => destiny.Name, option => option.MapFrom(src => src.Name))
                .ForMember(destiny => destiny.Air_Date, option => option.MapFrom(src => src.Air_Date))
                .ForMember(destiny => destiny.Episode, option => option.MapFrom(src => src.Episode))
                .ForMember(destiny => destiny.Url, option => option.MapFrom(src => src.Url))
            ;
        }
    }
}