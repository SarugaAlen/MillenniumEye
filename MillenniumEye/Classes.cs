// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
using Newtonsoft.Json;

public class CardImage
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; set; }

        [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
        public string? ImageUrl { get; set; }

        [JsonProperty("image_url_small", NullValueHandling = NullValueHandling.Ignore)]
        public string? ImageUrlSmall { get; set; }

        [JsonProperty("image_url_cropped", NullValueHandling = NullValueHandling.Ignore)]
        public string? ImageUrlCropped { get; set; }
    }

    public class CardPrice
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

    public class CardSet
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
        public List<CardSet>? CardSets { get; set; }

        [JsonProperty("card_images", NullValueHandling = NullValueHandling.Ignore)]
        public List<CardImage>? CardImages { get; set; }

        [JsonProperty("card_prices", NullValueHandling = NullValueHandling.Ignore)]
        public List<CardPrice>? CardPrices { get; set; }
    }

    public class Data
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public List<Card>? CardData { get; set; }
    }

