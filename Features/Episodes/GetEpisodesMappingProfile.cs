using AutoMapper;
using Infrastructure.RickandMortyAPI.Episodes;


namespace Features.Episodes.GetEpisodes
{
    public class GetEpisodesMappingProfile : Profile
    {
        public GetEpisodesMappingProfile()
        {
            CreateMap<EpisodeDto, GetEpisodeResponse>()
                .ForMember(destiny => destiny.Id, option => option.MapFrom(src => src.Id))
                .ForMember(destiny => destiny.Name, option => option.MapFrom(src => src.Name))
                .ForMember(destiny => destiny.Air_Date, option => option.MapFrom(src => src.Air_Date))
                .ForMember(destiny => destiny.Episode, option => option.MapFrom(src => src.Episode))
                .ForMember(destiny => destiny.Url, option => option.MapFrom(src => src.Url))
            ;
            CreateMap<EpisodesDto, GetEpisodesResponse>()
                .ForMember(destiny => destiny.Episodes, option => option.MapFrom(src => src.Results))
                .ForMember(destiny => destiny.TotalEpisodes, option => option.MapFrom(src => src.Info.Count))
                .ForMember(destiny => destiny.TotalPages, option => option.MapFrom(src => src.Info.Pages))
                .ForMember(destiny => destiny.NextPageUrl, option => option.MapFrom(src => src.Info.Next))
                .ForMember(destiny => destiny.PreviousPageUrl, option => option.MapFrom(src => src.Info.Prev))
                .AfterMap((src, dest, ctx) =>
                {
                    dest.ActualPage = (int)ctx.Items["Page"];
                });
        }
    }
}