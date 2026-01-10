using MediatR;


namespace Features.Episodes.GetEpisodes
{
    public sealed record GetEpisodesQuery : IRequest<List<GetEpisodesResponse>>;
}

