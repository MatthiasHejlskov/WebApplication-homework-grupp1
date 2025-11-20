using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication_homework_grupp1.Dates;

namespace WebApplication_homework_grupp1.Data.Services
{
    public interface ISkattService
    {
        Task<List<DateDto>> GetDatesAsync();                    //hämtar data från API
        Task<List<DateDto>> GetTaxableDates();                  //skapar en lista med datum som har trängselskatt
        Task<List<DateDto>> GetNonTaxableDates();               //skapar en lista med datum utan trängselskatt
        Task<List<DateDto>> GetDatesByMonth(string month);      //skapar en lista med datum i en specifik månad
    }
}
