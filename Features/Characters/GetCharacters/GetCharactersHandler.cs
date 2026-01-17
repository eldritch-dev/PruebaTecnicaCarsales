using MediatR;
using AutoMapper;
using Infrastructure.RickandMortyAPI.Characters;


namespace Features.Characters.GetCharacters
{
    public class GetCharactersHandler : IRequestHandler<GetCharactersQuery, GetCharactersResponse>
    {
        private readonly CharactersClient _client;
        private readonly IMapper _mapper;

        public GetCharactersHandler(CharactersClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<GetCharactersResponse> Handle(GetCharactersQuery request, CancellationToken cancellationToken)
        {
            var characters = await _client.GetCharactersAsync(request.page, request.gender, cancellationToken);
            return _mapper.Map<GetCharactersResponse>(characters, opts => opts.Items["Page"] = request.page);
        }
    }
}