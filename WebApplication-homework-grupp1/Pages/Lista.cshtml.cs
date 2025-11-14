using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication_homework_grupp1.Data.Services;
using WebApplication_homework_grupp1.Dates;

namespace WebApplication_homework_grupp1.Pages
{
    public class ListaModel : PageModel
    {
        private readonly ISkattService _skattService;

        public ListaModel(ISkattService skattService)
        {
            _skattService = skattService;
        }

        public IEnumerable<DateDto> Dates { get; set; } = Enumerable.Empty<DateDto>();

        public async Task OnGet()
        {
            Console.WriteLine("ListaModel.OnGet() körs!");
            Dates = await _skattService.GetDates();
            Console.WriteLine($"ListaModel mottog {Dates.Count()} rader.");
        }
    }
}