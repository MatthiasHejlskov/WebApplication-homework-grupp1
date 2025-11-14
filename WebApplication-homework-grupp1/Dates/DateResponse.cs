using System.Text.Json.Serialization;

namespace WebApplication_homework_grupp1.Dates
{
    public class DateResponse
    {
        [JsonPropertyName("resultCount")]
        public int Count { get; set; }

        [JsonPropertyName("results")]
        public List<DateDto>? Results { get; set; }
    }
}