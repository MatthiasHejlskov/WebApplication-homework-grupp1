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
            var response = await _httpClient.GetFromJsonAsync<DateResponse>("year=2025&_limit=365&_offset=0");

           if(response?.Results == null)
                return new List<DateDto>();

           return response.Results
                          .Select(item => new DateDto
                          {
                              Month = item.Month,
                              Year = item.Year,
                              TaxableDay = item.TaxableDay,
                              Day = item.Day,

                          }).ToList();
        }

    }
}
