using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication_homework_grupp1.Dates;

namespace WebApplication_homework_grupp1.Pages
{
    public class Test2Model : PageModel
    {
        public IEnumerable<DateDto> Dates { get; set; } = null!;
        public void OnGet()
        {
        }
    }
}
