using System.Text.Json.Serialization;

namespace WebApplication_homework_grupp1.Dates
{
    public class DateDto             //Date "data transfer object" 
    {
        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("month")]
        public string Month { get; set; } = null!;   //denna gör att det blir null om det inte finns nån data, annars ger kompilatorn felmeddelande.

        [JsonPropertyName("day")]
        public int Day { get; set; }

        [JsonPropertyName("taxable day")]
        public string TaxableDay { get; set; } = null!;
    }
}