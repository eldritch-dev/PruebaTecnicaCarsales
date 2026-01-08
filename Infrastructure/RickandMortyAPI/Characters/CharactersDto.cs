namespace Infrastructure.RickandMortyAPI.Characters
{
    public sealed class RickandMortyAPIDto
    {
        public InfoDto Info { get; init; } = new InfoDto();
        public List<CharacterDto> Results { get; init; } = [];

        public RickandMortyAPIDto()
        {
            
        }
    }

    public sealed class InfoDto
    {
        public long Count { get; init; }
        public int Pages { get; init; }
        public string Next { get; init; } = string.Empty;
        public string Prev { get; init; } = string.Empty;
    }

    public sealed class CharacterDto
    {
        public int Id { get; init; }
        public string Name { get; init;} = string.Empty;
        public string Status { get; init; } = string.Empty;
        public string Species { get; init; } = string.Empty;
        public string Type { get; init; } = string.Empty;
        public string Gender { get; init; } = string.Empty;
        public OriginDto Origin { get; init; } = new OriginDto();
        public LocationDto Location { get; init; } = new LocationDto();
        public string Image { get; init; } = string.Empty;
        public List<string> Episode { get; init; } = [];
        public string Url { get; init; } = string.Empty;
        public DateTime Created { get; init; }
    }

    public sealed class OriginDto
    {
        public string Name { get; init; } = string.Empty;
        public string Url { get; init; } = string.Empty;
    };

    public sealed class LocationDto
    {
        public string Name { get; init; } = string.Empty;
        public string Url { get; init; } = string.Empty;
    };   
}