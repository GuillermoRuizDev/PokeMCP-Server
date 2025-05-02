using ModelContextProtocol.Server;
using PokeMCP.Core.Interfaces;
using System.ComponentModel;

namespace PokeMCP.Tools;

public class PokeApiTool
{
    private readonly IPokemonRepository _pokemonRepository;
    public PokeApiTool(IPokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }
    [McpServerTool, Description("Fetches Pokemon data by ID or name.")]
    public async Task<string> GetPokemonInfo(string pokemonName)
    {
        return await _pokemonRepository.GetPokemonByIdOrName(pokemonName);
    }
}
