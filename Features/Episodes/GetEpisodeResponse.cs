namespace Features.Episodes.GetEpisodes 
{
    public sealed class GetEpisodeResponse 
    {
        public int Id { get; init; }
        public string Name { get; init;} = string.Empty;
        public string Air_Date { get; init; } = string.Empty;
        public string Episode { get; set; } = string.Empty;
        public string Url { get; init; } = string.Empty;
    }
}


