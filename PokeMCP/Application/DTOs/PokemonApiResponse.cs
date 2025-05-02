using Newtonsoft.Json;

namespace PokeMCP.Application.DTOs;

public class PokemonApiResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }

    [JsonProperty("types")]
    public List<TypeSlot> Types { get; set; }

    [JsonProperty("stats")]
    public List<StatResponse> Stats { get; set; }

    [JsonProperty("sprites")]
    public SpriteResponse Sprites { get; set; }
}

public class TypeSlot
{
    [JsonProperty("slot")]
    public int Slot { get; set; }

    [JsonProperty("type")]
    public TypeInfo Type { get; set; }
}

public class TypeInfo
{
    [JsonProperty("name")]
    public string Name { get; set; }
}

public class StatResponse
{
    [JsonProperty("base_stat")]
    public int BaseStat { get; set; }

    [JsonProperty("stat")]
    public StatInfo Stat { get; set; }
}

public class StatInfo
{
    [JsonProperty("name")]
    public string Name { get; set; }
}

public class SpriteResponse
{
    [JsonProperty("front_default")]
    public string FrontDefault { get; set; }
}