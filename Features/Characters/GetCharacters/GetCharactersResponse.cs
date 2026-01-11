namespace Features.Characters.GetCharacters
{
    public sealed class GetCharactersResponse 
    {
        public IReadOnlyList<GetCharacterResponse> Characters { get; init; } = [];
        public int TotalCharacters { get; init; }
        public int TotalPages { get; init; }
        public int ActualPage {get; set;}
        public string NextPageUrl { get; init; } = string.Empty;
        public string PreviousPageUrl { get; init; } = string.Empty;
    }
}


