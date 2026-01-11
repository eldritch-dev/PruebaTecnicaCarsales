using MediatR;


namespace Features.Characters.GetCharacters
{
    public sealed record GetCharactersQuery(int page) : IRequest<GetCharactersResponse>;
}

