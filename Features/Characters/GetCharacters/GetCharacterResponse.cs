namespace Features.Characters.GetCharacters
{
    public sealed class GetCharacterResponse 
    {
        public int Id { get; init; }
        public string Name { get; init;} = string.Empty;
        public string Species { get; init; } = string.Empty;
        public string Gender { get; init; } = string.Empty;
        public Origin Origin { get; init; } = new Origin();
        public string Image { get; init; } = string.Empty;
        public string Url { get; init; } = string.Empty;
    }

    public sealed class Origin
    {
        public string Name { get; init; } = string.Empty;
    }
}


