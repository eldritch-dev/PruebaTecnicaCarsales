using MediatR;
using AutoMapper;
using Infrastructure.RickandMortyAPI.Characters;


namespace Features.Characters.GetCharacters
{
    public class GetCharactersHandler : IRequestHandler<GetCharactersQuery, List<GetCharactersResponse>>
    {
        private readonly CharactersClient _client;
        private readonly IMapper _mapper;

        public GetCharactersHandler(CharactersClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<List<GetCharactersResponse>> Handle(GetCharactersQuery request, CancellationToken cancellationToken)
        {
            var characters = await _client.GetCharactersAsync();
            return _mapper.Map<List<GetCharactersResponse>>(characters);
        }
    }
}