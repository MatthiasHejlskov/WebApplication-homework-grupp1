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
            var response = await _httpClient.GetFromJsonAsync<DateResponse>("year=2026&_limit=365&_offset=0"); //vi ber om data för hela 2026

           if(response?.Results == null)                    //skapar en ny lista
                return new List<DateDto>();
           
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
