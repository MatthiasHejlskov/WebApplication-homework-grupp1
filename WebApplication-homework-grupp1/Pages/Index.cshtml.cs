using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication_homework_grupp1.Data.Services;
using WebApplication_homework_grupp1.Dates;
namespace WebApplication_homework_grupp1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ISkattService _taxService;

        public List<DateDto> WithTax { get; set; } = new();
        public List<DateDto> WithoutTax { get; set; } = new();
        public List<int> Months { get; set; } = new();
        public int TotalTax { get; set; } = 0;

        public IndexModel(ISkattService taxService)
        {
            _taxService = taxService;
        }

        public async Task OnGet()
        {
            var allDates = await _taxService.GetDates();

            var filterService = new DateFilterService();
            (WithTax, WithoutTax) = filterService.SplitByTax(allDates);

            var monthService = new MonthService();
            Months = monthService.GetUniqueMonths(allDates);

            TotalTax = WithTax.Sum(d => d.TaxableDay);
        }
    }
}


