using WebApplication_homework_grupp1.Dates;

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
            var url =
    "https://transportstyrelsen.entryscape.net/rowstore/dataset/42c48f61-274e-422f-afec-c76a6938f8c8?year=2026&_limit=365&_offset=0";

            var response = await _httpClient.GetFromJsonAsync<DateResponse>(url);
            if (response == null)
            {
                Console.WriteLine("API svarade null");
                return new List<DateDto>();
            }

           if (response?.Results == null)
           {
    Console.WriteLine("API innehåller inga Results");
    return new List<DateDto>();
           }


            Console.WriteLine($"Antal rader i API: {response.Results.Count}");
            return response.Results
                          .Select(item => new DateDto       //lägger in datan i listan.
                          {
                              Month = item.Month,       //måste kanske va liten bokstav i början på de här för att APIn har liten bokstav.
                              Year = item.Year,
                              TaxableDay = item.TaxableDay,
                              Day = item.Day,

                          }).ToList();
        }

    }
}
