namespace Infrastructure.RickandMortyAPI.Characters
{
    public sealed class CharactersClient
    {
        private readonly HttpClient _httpClient;

        public CharactersClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CharacterDto>> GetCharactersAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CharactersDto>("character");
            return response?.Results ?? new List<CharacterDto>();
        }
    }
}

