using ModelContextProtocol.Server;
using PokeMCP.Application.DTOs;
using PokeMCP.Core.Entities;
using PokeMCP.Core.Interfaces;
using System.ComponentModel;

namespace PokeMCP.Tools;

public class PokeFunctionsTool
{
    private readonly IBattleCalculator _battleCalculator;
    public PokeFunctionsTool(IBattleCalculator battleCalculator)
    {
        _battleCalculator = battleCalculator;
    }

    [McpServerTool, Description("Gets the result of the battle between 2 pokemon.")]
    public async Task<BattleResult> GetBattleResult(Pokemon attacker, Pokemon defenser)
    {
        return await _battleCalculator.CalculateBattleOutcome(attacker, defenser);
    }

    [McpServerTool, Description("Get probability of finding a shiny.")]
    public double ProbabilityFindingShiny(int encounters, bool hasShinyCharm = false)
    {
        return _battleCalculator.CalculateShinyProbability(encounters, hasShinyCharm);
    }
}
