using Newtonsoft.Json;

namespace MillenniumEye.model
{
    public class Image
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
}
