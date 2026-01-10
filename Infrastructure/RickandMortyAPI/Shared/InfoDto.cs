namespace Infrastructure.RickandMortyAPI.Shared
{
    public sealed class InfoDto
    {
        public long Count { get; init; }
        public int Pages { get; init; }
        public string Next { get; init; } = string.Empty;
        public string Prev { get; init; } = string.Empty;
    } 
}