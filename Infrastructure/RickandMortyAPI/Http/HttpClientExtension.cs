using Microsoft.Extensions.Options;
using Infrastructure.RickandMortyAPI.Http;

public static class HttpClientExtension
{
    public static IHttpClientBuilder AddRickAndMortyHttpApiClient<TClient>(this IServiceCollection services) where TClient : class
    {
        return services.AddHttpClient<TClient>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<ApiOptions>>().Value;
            client.BaseAddress = new Uri(options.BaseUrl);
        });
    }
}