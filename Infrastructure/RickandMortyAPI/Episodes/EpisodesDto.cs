using Infrastructure.RickandMortyAPI.Shared;


namespace Infrastructure.RickandMortyAPI.Episodes
{
    public sealed class EpisodesDto
    {
        public InfoDto Info { get; init; } = new InfoDto();
        public List<EpisodeDto> Results { get; init; } = [];

        public EpisodesDto()
        {
            
        }
    }

    public sealed class EpisodeDto
    {
        public int Id { get; init; }
        public string Name { get; init;} = string.Empty;
        public string Air_Date { get; init; } = string.Empty;
        public string Episode { get; init; } = string.Empty;
        public List<string> Characters { get; init; } = [];
        public string Url { get; init; } = string.Empty;
        public DateTime Created { get; init; }
    }  
}