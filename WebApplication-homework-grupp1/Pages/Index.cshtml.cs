using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication_homework_grupp1.Data.Services;

namespace WebApplication_homework_grupp1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ISkattService _skattService;

        public List<DateDto> Dates { get; set; } = new();

        public IndexModel(ISkattService skattService)
        {
            _skattService = skattService;
        }

        public async Task OnGet()
        {
            Dates = await _skattService.GetDates();

            Console.WriteLine("Antal rader mottagna: " + Dates.Count);
            foreach (var d in Dates)
            {
                Console.WriteLine($"{d.Year}-{d.Month}-{d.Day} TaxableDay: {d.TaxableDay}");
            }
        }
    }
}
