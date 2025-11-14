using System.Text.Json.Serialization;

namespace WebApplication_homework_grupp1.Dates
{
    public class DateResponse
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; } = null!;

        [JsonPropertyName("results")]
        public List<DateDto>? Results { get; set; }
    }
}