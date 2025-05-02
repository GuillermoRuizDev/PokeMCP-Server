using PokeMCP.Core.Enums;

namespace PokeMCP.Core.Interfaces;
public interface IPokemonRepository
{
    Task<string> GetPokemonByIdOrName(string identifier);
    Task<TypeEffectiveness> GetTypeEffectiveness(string attackType, string defendType);
}