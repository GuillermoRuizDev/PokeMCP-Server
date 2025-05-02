using PokeMCP.Application.UseCases;
using PokeMCP.Core.Interfaces;
using PokeMCP.Infrastructure.Clients;
using PokeMCP.Infrastructure.Repositories;

namespace PokeMCP;
public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<PokeApiClient>();
        services.AddScoped<IPokemonRepository, PokemonRepository>();
        services.AddScoped<IBattleCalculator, BattleCalculator>();

        return services;
    }
}
