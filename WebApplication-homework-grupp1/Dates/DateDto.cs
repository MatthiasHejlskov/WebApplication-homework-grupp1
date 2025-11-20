using System.Text.Json.Serialization;

namespace WebApplication_homework_grupp1.Dates
{
    public class DateDto            //Hanterar data variablerna från APIn.
    {
      

        [JsonPropertyName("month")]
        public string Month { get; set; } = string.Empty;

        [JsonPropertyName("day")]
        public int Day { get; set; }

        [JsonPropertyName("taxable day")]
        public string TaxableDay { get; set; } = string.Empty;
    }
}


