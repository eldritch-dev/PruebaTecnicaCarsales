namespace Infrastructure.RickandMortyAPI.Episodes
{
    public sealed class EpisodesClient
    {
        private readonly HttpClient _httpClient;

        public EpisodesClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EpisodeDto>> GetEpisodesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<EpisodesDto>("episode");
            return response?.Results ?? new List<EpisodeDto>();
        }
    }
}

