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
    [McpServerTool, Description("Gets Pokemon data by ID or name.")]
    public async Task<string> GetPokemonInformation([Description("name or id of the pokemon")] string pokemonName)
    {
        return await _pokemonRepository.GetPokemonByIdOrName(pokemonName);
    }
}
