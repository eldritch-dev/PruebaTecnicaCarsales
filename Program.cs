using Features.Characters.GetCharacters;
using Features.Episodes.GetEpisodes;
using Infrastructure.RickandMortyAPI.Characters;
using Infrastructure.RickandMortyAPI.Episodes;
using MediatR;
using Infrastructure.RickandMortyAPI.Http;
using Microsoft.AspNetCore.Mvc;
using Features.Characters.SearchCharacters;

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
    options.AddPolicy("All", policy =>
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

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.ContentType = "application/json";

        var exceptionHandlerPathFeature =
            context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();

        var error = new
        {
            error =  exceptionHandlerPathFeature?.Error.Message ?? "An error occurred.",
            traceId = context.TraceIdentifier   
        };
        
        context.Response.StatusCode = 500;
        await context.Response.WriteAsJsonAsync(error);
    });
});

app.UseCors("All");

app.MapGet("/episodes", async ([FromQuery] int page, IMediator mediator) =>
{
    var episodes = await mediator.Send(new GetEpisodesQuery(page));
    return Results.Ok(episodes);
});

app.MapGet("/characters", async ([FromQuery] int page, [FromQuery] string? name, [FromQuery] string? species, [FromQuery] string? gender, IMediator mediator) =>
{
    var characters = await mediator.Send(new GetCharactersQuery(page, name, species, gender));
    return Results.Ok(characters);
});

app.MapGet("/characters/search", async ([FromQuery] string query, IMediator mediator) =>
{
    var characters = await mediator.Send(new SearchCharactersQuery(query));
    return Results.Ok(characters);
});

app.MapGet("/implicit-error", (int a = 0, int b = 0) =>
{
    return a / b;
});

app.MapGet("/explicit-error", () => 
{ 
    throw new Exception("Test error");
});

app.Run();
