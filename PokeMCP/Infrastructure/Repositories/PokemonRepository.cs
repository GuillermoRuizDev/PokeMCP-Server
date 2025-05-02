using Newtonsoft.Json;
using PokeMCP.Application.DTOs;
using PokeMCP.Core.Entities;
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
        var response = await _apiClient.GetResourceAsync<PokemonApiResponse>($"pokemon/{identifier.ToLower()}");

        // Mapear la respuesta API al modelo de dominio
        var pokemon = new Pokemon
        {
            Id = response.Id,
            Name = response.Name,
            Height = response.Height,
            Weight = response.Weight,
            Types = response.Types.Select(t => new PokemonType { Name = t.Type.Name }).ToList(),
            Stats = response.Stats.Select(s => new Stat
            {
                Name = s.Stat.Name,
                BaseValue = s.BaseStat
            }).ToList(),
            Sprites = new Sprite { FrontDefault = response.Sprites.FrontDefault }
        };

        return JsonConvert.SerializeObject(pokemon);
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