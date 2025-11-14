using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApplication_homework_grupp1.Dates
{
    public class DateResponse
    {
        [JsonPropertyName("results")]
        public List<DateDto> Results { get; set; } = new();
    }
}
