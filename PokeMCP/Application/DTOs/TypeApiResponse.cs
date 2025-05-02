using Newtonsoft.Json;

namespace PokeMCP.Application.DTOs;

public class TypeApiResponse
{
    [JsonProperty("damage_relations")]
    public DamageRelations DamageRelations { get; set; }
}

public class DamageRelations
{
    [JsonProperty("double_damage_to")]
    public List<TypeResource> DoubleDamageTo { get; set; } = new List<TypeResource>();

    [JsonProperty("half_damage_to")]
    public List<TypeResource> HalfDamageTo { get; set; } = new List<TypeResource>();

    [JsonProperty("no_damage_to")]
    public List<TypeResource> NoDamageTo { get; set; } = new List<TypeResource>();
}

public class TypeResource
{
    [JsonProperty("name")]
    public string Name { get; set; }
}
