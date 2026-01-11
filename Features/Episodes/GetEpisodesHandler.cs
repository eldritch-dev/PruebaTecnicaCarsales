using MediatR;
using AutoMapper;
using Infrastructure.RickandMortyAPI.Episodes;


namespace Features.Episodes.GetEpisodes
{
    public class GetEpisodesHandler : IRequestHandler<GetEpisodesQuery, GetEpisodesResponse>
    {
        private readonly EpisodesClient _client;
        private readonly IMapper _mapper;

        public GetEpisodesHandler(EpisodesClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<GetEpisodesResponse> Handle(GetEpisodesQuery request, CancellationToken cancellationToken)
        {
            var episodes = await _client.GetEpisodesAsync(request.Page, cancellationToken);
            return _mapper.Map<GetEpisodesResponse>(episodes, opts => opts.Items["Page"] = request.Page);
        }
    }
}