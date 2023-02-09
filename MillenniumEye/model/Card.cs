using Newtonsoft.Json;

namespace MillenniumEye.model
{
    public class Card
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string? Name { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string? Type { get; set; }

        [JsonProperty("frameType", NullValueHandling = NullValueHandling.Ignore)]
        public string? FrameType { get; set; }

        [JsonProperty("desc", NullValueHandling = NullValueHandling.Ignore)]
        public string? Desc { get; set; }

        [JsonProperty("atk", NullValueHandling = NullValueHandling.Ignore)]
        public int? Atk { get; set; }

        [JsonProperty("def", NullValueHandling = NullValueHandling.Ignore)]
        public int? Def { get; set; }

        [JsonProperty("level", NullValueHandling = NullValueHandling.Ignore)]
        public int? Level { get; set; }

        [JsonProperty("race", NullValueHandling = NullValueHandling.Ignore)]
        public string? Race { get; set; }

        [JsonProperty("attribute", NullValueHandling = NullValueHandling.Ignore)]
        public string? Attribute { get; set; }

        [JsonProperty("archetype", NullValueHandling = NullValueHandling.Ignore)]
        public string? Archetype { get; set; }

        [JsonProperty("card_sets", NullValueHandling = NullValueHandling.Ignore)]
        public List<Set>? CardSets { get; set; }

        [JsonProperty("card_images", NullValueHandling = NullValueHandling.Ignore)]
        public List<Image>? CardImages { get; set; }

        [JsonProperty("card_prices", NullValueHandling = NullValueHandling.Ignore)]
        public List<Price>? CardPrices { get; set; }
    }
}
