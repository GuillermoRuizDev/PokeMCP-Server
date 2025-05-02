namespace PokeMCP.Application.DTOs;

public class BattleResult
{
    public string Attacker { get; set; }
    public string Defender { get; set; }
    public double EstimatedDamage { get; set; }
    public string Effectiveness { get; set; }
}
