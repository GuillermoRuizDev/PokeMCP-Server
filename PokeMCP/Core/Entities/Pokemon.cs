namespace PokeMCP.Core.Entities;
public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Height { get; set; } // In decimeters
    public int Weight { get; set; } // In hectograms
    public List<PokemonType> Types { get; set; }
    public List<Stat> Stats { get; set; }
    public Sprite Sprites { get; set; }
}

public class Stat
{
    public string Name { get; set; }
    public int BaseValue { get; set; }
}

public class PokemonType
{
    public string Name { get; set; }
}

public class Sprite
{
    public string FrontDefault { get; set; }
}