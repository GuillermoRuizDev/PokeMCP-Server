using PokeMCP.Application.DTOs;
using PokeMCP.Core.Entities;
using PokeMCP.Core.Interfaces;

namespace PokeMCP.Application.UseCases;
public class BattleCalculator : IBattleCalculator
{
    private readonly IPokemonRepository _pokemonRepository;

    public BattleCalculator(IPokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }

    public double CalculateShinyProbability(int encounters, bool hasShinyCharm = false)
    {
        double baseRate = hasShinyCharm ? 1.0 / 512 : 1.0 / 4096;
        return 1 - Math.Pow(1 - baseRate, encounters);
    }
    public async Task<BattleResult> CalculateBattleOutcome(Pokemon attacker, Pokemon defender)
    {
        var damage = await CalculateDamage(attacker, defender);
        return new BattleResult
        {
            Attacker = attacker.Name,
            Defender = defender.Name,
            EstimatedDamage = damage,
            Effectiveness = GetEffectivenessDescription(damage)
        };
    }

    private async Task<double> CalculateDamage(Pokemon attacker, Pokemon defender)
    {
        // Simplified damage formula
        const int baseDamage = 50;
        var attackStat = attacker.Stats.FirstOrDefault(s => s.Name == "attack")?.BaseValue ?? 0;
        var defenseStat = defender.Stats.FirstOrDefault(s => s.Name == "defense")?.BaseValue ?? 0;
        var typeMultiplier = CalculateTypeMultiplier(attacker.Types.First().Name, defender.Types);

        return (double)((baseDamage * attackStat / defenseStat) * typeMultiplier);
    }

    private double CalculateTypeMultiplier(string attackType, List<PokemonType> defenderTypes)
    {
        double multiplier = 1.0;
        foreach (var defenderType in defenderTypes)
        {
            var effectiveness = _pokemonRepository.GetTypeEffectiveness(attackType, defenderType.Name).Result;
            multiplier *= (int)effectiveness / 10.0;
        }
        return multiplier;
    }


    private string GetEffectivenessDescription(double multiplier)
    {
        return multiplier switch
        {
            0.0 => "It has no effect!",
            >= 2.0 => "It's super effective!",
            <= 0.5 => "It's not very effective...",
            _ => "Standard effectiveness"
        };
    }
}



