using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication_homework_grupp1.Data.Services;
using WebApplication_homework_grupp1.Dates;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_homework_grupp1.Pages
{
    public class ListaModel : PageModel
    {
        private readonly ISkattService _skattService;

        public ListaModel(ISkattService skattService)
        {
            _skattService = skattService;
        }

        public List<DateDto> TaxedDates { get; set; } = new();
        public List<DateDto> NoTaxDates { get; set; } = new();
        public List<string> Months { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string SelectedMonth { get; set; } = "";

        public async Task OnGetAsync()
        {
            var dates = await _skattService.GetDates();
            var processor = new DateProcessor(dates);

            Months = processor.GetUniqueMonths();

            if (!string.IsNullOrEmpty(SelectedMonth))
            {
                TaxedDates = processor.GetDatesByMonth(SelectedMonth)
                                      .Where(d => d.TaxableDay != "0" && d.TaxableDay.ToLower() != "no")
                                      .ToList();
                NoTaxDates = processor.GetDatesByMonth(SelectedMonth)
                                      .Where(d => d.TaxableDay == "0" || d.TaxableDay.ToLower() == "no")
                                      .ToList();
            }
            else
            {
                TaxedDates = processor.GetTaxedDates();
                NoTaxDates = processor.GetNoTaxDates();
            }
        }
    }
}
