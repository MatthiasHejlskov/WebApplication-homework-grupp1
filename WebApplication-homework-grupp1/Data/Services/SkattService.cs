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

        public async Task<List<DateDto>> GetDatesAsync()   //hämtar data från API och skapar en lista med alla datum
        {
           

            var url = "https://transportstyrelsen.entryscape.net/rowstore/dataset/42c48f61-274e-422f-afec-c76a6938f8c8?year=2025&_limit=365&_offset=0";

            var response = await _httpClient.GetFromJsonAsync<DateResponse>(url);

            if (response?.Results == null)              //om API inte svarar, eller svarar med 0 rader skapas en tom lista
            {
                
                return new List<DateDto>();
            }

            

            return response.Results                     //om API svarar med data som väntat skapas en lista med datum och de variabler vi vill ha
                           .Select(item => new DateDto
                           {
                               Month = item.Month,
                               Day = item.Day,
                               TaxableDay = item.TaxableDay
                           }).ToList();
        }
        public async Task<List<DateDto>> GetTaxableDates()      //skapar en lista med datum som har trängselskatt
        {
            var allDates = await GetDatesAsync();               //hämtar listan med alla datum från GetDatesAsync

            return allDates                                     //returnerar ny lista där alla datum med "Yes" i taxableDay läggs in
                .Where(d => d.TaxableDay?.Equals("Yes") == true)
                .ToList();
        }
        public async Task<List<DateDto>> GetNonTaxableDates()   //skapar en lista med datum utan trängselskatt
        {
            var allDates = await GetDatesAsync();                //hämtar listan med alla datum från GetDatesAsync

            return allDates                                     //returnerar ny lista där alla datum med "No" i taxableDay läggs in
                .Where(d => d.TaxableDay?.Equals("No") == true)
                .ToList();
        }
        
        public async Task<List<DateDto>> GetDatesByMonth(string month)  // Filtrerar datum på vald månad
        {
            var allDates = await GetDatesAsync();               //hämtar listan med alla datum från GetDatesAsync
            return allDates                                     //returnerar ny lista där alla datum med den efterfrågade månaden i month läggs in
                .Where(d => d.Month == month)
                .ToList();
        }
    }
}
        
    

