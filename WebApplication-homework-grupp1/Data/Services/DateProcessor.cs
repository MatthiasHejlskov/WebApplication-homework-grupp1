using System.Collections.Generic;
using System.Linq;
using WebApplication_homework_grupp1.Dates;

namespace WebApplication_homework_grupp1.Data.Services
{
    public class DateProcessor
    {
        private readonly List<DateDto> _dates;

        public DateProcessor(List<DateDto> dates)
        {
            _dates = dates;
        }

        // Hämtar alla datum utan trängselskatt
        public List<DateDto> GetNoTaxDates()
        {
            return _dates
                .Where(d => d.TaxableDay == "0" || d.TaxableDay.ToLower() == "no")
                .ToList();
        }

        // Hämtar alla datum med trängselskatt
        public List<DateDto> GetTaxedDates()
        {
            return _dates
                .Where(d => d.TaxableDay != "0" && d.TaxableDay.ToLower() != "no")
                .ToList();
        }

        // Skapar en lista över unika månader
        public List<string> GetUniqueMonths()
        {
            return _dates
                .Select(d => d.Month)
                .Distinct()
                .OrderBy(m => m)
                .ToList();
        }

        // Filtrerar datum på vald månad
        public List<DateDto> GetDatesByMonth(string month)
        {
            return _dates
                .Where(d => d.Month == month)
                .ToList();
        }
    }
}
