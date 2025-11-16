using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication_homework_grupp1.Data.Services;
using WebApplication_homework_grupp1.Dates;

public class TaxableDaysModel : PageModel
{
    private readonly ISkattService _skattService;

    public List<DateDto> Days { get; set; } = new();

    public TaxableDaysModel(ISkattService skattService)
    {
        _skattService = skattService;
    }

    public async Task OnGet()
    {
        Days = await _skattService.GetTaxableDates();
    }
}