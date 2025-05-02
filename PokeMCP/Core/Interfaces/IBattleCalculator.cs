using PokeMCP.Application.DTOs;
using PokeMCP.Core.Entities;

namespace PokeMCP.Core.Interfaces;

public interface IBattleCalculator
{
    Task<BattleResult> CalculateBattleOutcome(Pokemon attacker, Pokemon defender);
    double CalculateShinyProbability(int encounters, bool hasShinyCharm = false);
}
