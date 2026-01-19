using System.Net;


namespace Infrastructure.RickandMortyAPI.Characters
{
    public sealed class CharactersClient
    {
        private readonly HttpClient _httpClient;

        public CharactersClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CharactersDto> GetCharactersAsync(int page, string? name, string? species, string? gender, CancellationToken cancellationToken)
        {
            var query = new List<string> { $"page={page}" };
            if (!string.IsNullOrWhiteSpace(name))
                query.Add($"name={ Uri.EscapeDataString(name) }");
            if (!string.IsNullOrWhiteSpace(species))
                query.Add($"species={ Uri.EscapeDataString(species) }");
            if (!string.IsNullOrWhiteSpace(gender))
                query.Add($"gender={ Uri.EscapeDataString(gender) }");
            var url = "character?" + string.Join("&", query);
            
            var response = await _httpClient.GetFromJsonAsync<CharactersDto>(url, cancellationToken);
            return response ?? new CharactersDto();
        }

        public async Task<IReadOnlyList<CharacterDto>> SearchCharactersAsync(string query, CancellationToken cancellationToken)
        {
            try
            {
                var url = $"character?name={Uri.EscapeDataString(query)}";

                var response = await _httpClient.GetFromJsonAsync<CharactersDto>(url, cancellationToken);
                return response?.Results ?? [];
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return [];
            }
        }
    }
}

