using Newtonsoft.Json;

namespace MillenniumEye.model
{
    public class Data
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public List<Card>? CardData { get; set; }
    }
}
