using Features.Characters.GetCharacters;
using Features.Episodes.GetEpisodes;
using Infrastructure.RickandMortyAPI.Characters;
using Infrastructure.RickandMortyAPI.Episodes;
using MediatR;
using Infrastructure.RickandMortyAPI.Http;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(GetCharactersMappingProfile));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetCharactersHandler>());
builder.Services.AddAutoMapper(typeof(GetEpisodesMappingProfile));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetEpisodesHandler>());

builder.Services
    .AddOptions<ApiOptions>()
    .Bind(builder.Configuration.GetSection("RickAndMortyApi"))
    .Validate(o => !string.IsNullOrWhiteSpace(o.BaseUrl), "Url base no funciona")
    .ValidateOnStart();

builder.Services.AddRickAndMortyHttpApiClient<CharactersClient>();
builder.Services.AddRickAndMortyHttpApiClient<EpisodesClient>();

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

app.MapGet("/episodes", async ([FromQuery] int page, IMediator mediator) =>
{
    var episodes = await mediator.Send(new GetEpisodesQuery(page));
    return Results.Ok(episodes);
});

app.MapGet("/characters", async (IMediator mediator) =>
{
    var characters = await mediator.Send(new GetCharactersQuery());
    return Results.Ok(characters);
});

app.Run();
