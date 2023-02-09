using Newtonsoft.Json;

namespace MillenniumEye.model
{
    public class Price
    {
        [JsonProperty("cardmarket_price", NullValueHandling = NullValueHandling.Ignore)]
        public string? CardmarketPrice { get; set; }

        [JsonProperty("tcgplayer_price", NullValueHandling = NullValueHandling.Ignore)]
        public string? TcgplayerPrice { get; set; }

        [JsonProperty("ebay_price", NullValueHandling = NullValueHandling.Ignore)]
        public string? EbayPrice { get; set; }

        [JsonProperty("amazon_price", NullValueHandling = NullValueHandling.Ignore)]
        public string? AmazonPrice { get; set; }

        [JsonProperty("coolstuffinc_price", NullValueHandling = NullValueHandling.Ignore)]
        public string? CoolstuffincPrice { get; set; }
    }
}
