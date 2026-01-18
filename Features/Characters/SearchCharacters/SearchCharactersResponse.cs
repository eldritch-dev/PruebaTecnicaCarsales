using Infrastructure.RickandMortyAPI.Characters;


namespace Features.Characters.SearchCharacters
{
    public sealed record SearchCharactersResponse(IReadOnlyList<SearchCharacterDto> Characters);
}


