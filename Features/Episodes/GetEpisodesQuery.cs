using MediatR;


namespace Features.Episodes.GetEpisodes
{
    public sealed record GetEpisodesQuery(int Page) : IRequest<GetEpisodesResponse>;
}

