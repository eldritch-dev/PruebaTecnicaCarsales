using MediatR;


namespace Features.Characters.GetCharacters
{
    public sealed record GetCharactersQuery : IRequest<List<GetCharactersResponse>>;
}

