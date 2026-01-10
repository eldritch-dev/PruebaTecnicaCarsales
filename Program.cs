using Features.Characters.GetCharacters;
using Features.Episodes.GetEpisodes;
using Infrastructure.RickandMortyAPI.Characters;
using Infrastructure.RickandMortyAPI.Episodes;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(GetCharactersMappingProfile));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetCharactersHandler>());
builder.Services.AddAutoMapper(typeof(GetEpisodesMappingProfile));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetEpisodesHandler>());

builder.Services.AddHttpClient<CharactersClient>(client =>
{
    var baseUrl = builder.Configuration["RickandMortyAPI:BaseUrl"];
    if (string.IsNullOrWhiteSpace(baseUrl))
    {
        throw new InvalidOperationException("Url base no funciona");
    }
    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddHttpClient<EpisodesClient>(client =>
{
    var baseUrl = builder.Configuration["RickandMortyAPI:BaseUrl"];
    if (string.IsNullOrWhiteSpace(baseUrl))
    {
        throw new InvalidOperationException("Url base no funciona");
    }
    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("Todos", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Todos");

app.MapGet("/episodes", async (IMediator mediator) =>
{
    var episodes = await mediator.Send(new GetEpisodesQuery());
    return Results.Ok(episodes);
});

app.MapGet("/characters", async (IMediator mediator) =>
{
    var characters = await mediator.Send(new GetCharactersQuery());
    return Results.Ok(characters);
});

app.Run();
