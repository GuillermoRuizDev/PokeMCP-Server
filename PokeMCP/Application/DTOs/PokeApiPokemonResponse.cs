using PokeMCP.Application.UseCases;

namespace PokeMCP.Application.DTOs;

public class PokeApiPokemonResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public List<PokemonTypeResponse> Types { get; set; }
    public List<StatResponse> Stats { get; set; }
    public SpriteResponse Sprites { get; set; }
}

public class StatResponse
{
    public int BaseStat { get; set; }
    public TypeResource Stat { get; set; }
}

public class PokemonTypeResponse
{
    public TypeResource Type { get; set; }
}

public class SpriteResponse
{
    public string FrontDefault { get; set; }
}
