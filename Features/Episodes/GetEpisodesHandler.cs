using MediatR;
using AutoMapper;
using Infrastructure.RickandMortyAPI.Episodes;


namespace Features.Episodes.GetEpisodes
{
    public class GetEpisodesHandler : IRequestHandler<GetEpisodesQuery, List<GetEpisodesResponse>>
    {
        private readonly EpisodesClient _client;
        private readonly IMapper _mapper;

        public GetEpisodesHandler(EpisodesClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<List<GetEpisodesResponse>> Handle(GetEpisodesQuery request, CancellationToken cancellationToken)
        {
            var episodes = await _client.GetEpisodesAsync();
            return _mapper.Map<List<GetEpisodesResponse>>(episodes);
        }
    }
}