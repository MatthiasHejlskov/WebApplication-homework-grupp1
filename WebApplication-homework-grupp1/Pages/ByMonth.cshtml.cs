using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication_homework_grupp1.Data.Services;
using WebApplication_homework_grupp1.Dates;

public class DatesByMonthModel : PageModel
{
    private readonly ISkattService _skattService;

    public List<DateDto> Dates { get; set; } = new();
    public string SelectedMonth { get; set; } = "";

    public DatesByMonthModel(ISkattService skattService)
    {
        _skattService = skattService;
    }

    public async Task OnGet(string month)
    {
        SelectedMonth = month;

        if (!string.IsNullOrEmpty(month))
        {
            Dates = await _skattService.GetDatesByMonth(month);
        }
    }
}
