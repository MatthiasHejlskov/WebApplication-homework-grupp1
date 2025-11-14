using WebApplication_homework_grupp1.Dates;
using System.Net.Http;
using System.Net.Http.Json;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication_homework_grupp1.Data.Services
{
    public class SkattService : ISkattService
    {
        private readonly HttpClient _httpClient;

        public SkattService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DateDto>> GetDates()
        {
            Console.WriteLine("SkattService.GetDates() körs!");

            var url = "https://transportstyrelsen.entryscape.net/rowstore/dataset/42c48f61-274e-422f-afec-c76a6938f8c8?year=2025&_limit=365&_offset=0";

            // Hämta API-data som DateResponse
            var response = await _httpClient.GetFromJsonAsync<DateResponse>(url);

            if (response?.Results == null)
            {
                Console.WriteLine("API innehåller inga Results");
                return new List<DateDto>();
            }

            Console.WriteLine($"Antal rader i API: {response.Results.Count}");

            // Mappa API-data → DateDto
            return response.Results
                           .Select(item => new DateDto
                           {
                               Year = item.Year,
                               Month = item.Month,         // string → string (OK)
                               Day = item.Day,
                               TaxableDay = item.TaxableDay // string → string (OK)
                           }).ToList();
        }
    }
}
