using MediatR;
using AutoMapper;
using Infrastructure.RickandMortyAPI.Characters;


namespace Features.Characters.SearchCharacters
{
    public class GetSuggestionsHandler : IRequestHandler<SearchCharactersQuery, SearchCharactersResponse>
    {
        private readonly CharactersClient _client;
        private readonly IMapper _mapper;

        public GetSuggestionsHandler(CharactersClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<SearchCharactersResponse> Handle(SearchCharactersQuery request, CancellationToken cancellationToken)
        {
            var results = await _client.SearchCharactersAsync(request.query, cancellationToken);
            var characters = _mapper.Map<IReadOnlyList<SearchCharacterDto>>(results);
            return new SearchCharactersResponse(characters);
        }
    }
}