using Newtonsoft.Json;

namespace MillenniumEye.model
{
    public class Card
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public List<Datum>? Data { get; set; }
    }
}
