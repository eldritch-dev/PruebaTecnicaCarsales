namespace Features.Episodes.GetEpisodes 
{
    public sealed class GetEpisodesResponse 
    {
        public IReadOnlyList<GetEpisodeResponse> Episodes { get; init; } = [];
        public int TotalEpisodes { get; init; }
        public int TotalPages { get; init; }
        public int ActualPage {get; set;}
        public string NextPageUrl { get; init; } = string.Empty;
        public string PreviousPageUrl { get; init; } = string.Empty;

    }
}


