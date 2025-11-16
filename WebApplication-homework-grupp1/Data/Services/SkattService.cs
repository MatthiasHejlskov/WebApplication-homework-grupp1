using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApplication_homework_grupp1.Dates;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task<List<DateDto>> GetTaxableDates()
        {
            var allDates = await GetDatesAsync();

            return allDates
                .Where(d => d.TaxableDay?.Equals("Yes") == true)
                .ToList();
        }
        public async Task<List<DateDto>> GetNonTaxableDates()
        {
            var allDates = await GetDatesAsync();

            return allDates
                .Where(d => d.TaxableDay?.Equals("No") == true)
                .ToList();
        }
        // Filtrerar datum på vald månad
        public async Task<List<DateDto>> GetDatesByMonth(string month)
        {
            var allDates = await GetDatesAsync();
            return allDates
                .Where(d => d.Month == month)
                .ToList();
        }
    }
}
        
    

