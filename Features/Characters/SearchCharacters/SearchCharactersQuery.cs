using MediatR;


namespace Features.Characters.SearchCharacters
{
    public sealed record SearchCharactersQuery(string query) : IRequest<SearchCharactersResponse>;
}

