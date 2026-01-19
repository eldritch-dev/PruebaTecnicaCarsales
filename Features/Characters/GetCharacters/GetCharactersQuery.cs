using MediatR;


namespace Features.Characters.GetCharacters
{
    public sealed record GetCharactersQuery(int page, string? name, string? species, string? gender) : IRequest<GetCharactersResponse>;
}

