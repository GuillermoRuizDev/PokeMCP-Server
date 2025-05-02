using Newtonsoft.Json;
using PokeMCP.Application.DTOs;
using PokeMCP.Core.Enums;
using PokeMCP.Core.Interfaces;
using PokeMCP.Infrastructure.Clients;

namespace PokeMCP.Infrastructure.Repositories;

public class PokemonRepository : IPokemonRepository
{
    private readonly PokeApiClient _apiClient;

    public PokemonRepository(PokeApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<string> GetPokemonByIdOrName(string identifier)
    {
        var response = await _apiClient.GetResourceAsync<PokeApiPokemonResponse>($"pokemon/{identifier.ToLower()}");
        return JsonConvert.SerializeObject(response);
    }

    public async Task<TypeEffectiveness> GetTypeEffectiveness(string attackType, string defendType)
    {
        var typeData = await _apiClient.GetResourceAsync<TypeApiResponse>($"type/{attackType.ToLower()}");
        var defendTypeLower = defendType.ToLower();

        // Check for immunity
        if (typeData.DamageRelations.NoDamageTo.Any(t => t.Name == defendTypeLower))
            return TypeEffectiveness.Immune;

        // Check for resistance
        if (typeData.DamageRelations.HalfDamageTo.Any(t => t.Name == defendTypeLower))
            return TypeEffectiveness.NotEffective;

        // Check for super effectiveness
        if (typeData.DamageRelations.DoubleDamageTo.Any(t => t.Name == defendTypeLower))
            return TypeEffectiveness.SuperEffective;

        return TypeEffectiveness.Normal;
    }
}