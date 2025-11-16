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

        public async Task<List<DateDto>> GetDatesAsync()   // <-- ändrat till Async
        {
           

            var url = "https://transportstyrelsen.entryscape.net/rowstore/dataset/42c48f61-274e-422f-afec-c76a6938f8c8?year=2025&_limit=365&_offset=0";

            var response = await _httpClient.GetFromJsonAsync<DateResponse>(url);

            if (response?.Results == null)
            {
                
                return new List<DateDto>();
            }

            

            return response.Results
                           .Select(item => new DateDto
                           {
                               Month = item.Month,
                               Day = item.Day,
                               TaxableDay = item.TaxableDay
                           }).ToList();
        }
    }
}
