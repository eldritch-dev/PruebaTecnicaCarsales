namespace Infrastructure.RickandMortyAPI.Characters
{
    public sealed class CharactersClient
    {
        private readonly HttpClient _httpClient;

        public CharactersClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CharactersDto> GetCharactersAsync(int page, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<CharactersDto>($"character?page={page}", cancellationToken);
            return response ?? new CharactersDto();
        }
    }
}

