using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.RickandMortyAPI.Episodes
{
    public sealed class EpisodesClient
    {
        private readonly HttpClient _httpClient;

        public EpisodesClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EpisodesDto> GetEpisodesAsync(int page, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<EpisodesDto>($"episode?page={page}", cancellationToken);
            return response ?? new EpisodesDto();
        }
    }
}

