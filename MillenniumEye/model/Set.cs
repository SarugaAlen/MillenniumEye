using Newtonsoft.Json;

namespace MillenniumEye.model
{
    public class Set
    {
        [JsonProperty("set_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? SetName { get; set; }

        [JsonProperty("set_code", NullValueHandling = NullValueHandling.Ignore)]
        public string? SetCode { get; set; }

        [JsonProperty("set_rarity", NullValueHandling = NullValueHandling.Ignore)]
        public string? SetRarity { get; set; }

        [JsonProperty("set_rarity_code", NullValueHandling = NullValueHandling.Ignore)]
        public string? SetRarityCode { get; set; }

        [JsonProperty("set_price", NullValueHandling = NullValueHandling.Ignore)]
        public string? SetPrice { get; set; }
    }
}
