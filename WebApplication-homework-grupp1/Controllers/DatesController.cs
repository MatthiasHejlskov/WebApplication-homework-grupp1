using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using WebApplication_homework_grupp1.Data.Services;


namespace WebApplication_homework_grupp1.Controllers
{
    public class DatesController : Controller
    {
        private readonly ISkattService _skattService;
        public DatesController(ISkattService skattService)
        {
            _skattService = skattService;
        }

        public async Task<IActionResult> Index()
        {
            var dates = await _skattService.GetDates();
            return View(dates);
        }
    }
}
