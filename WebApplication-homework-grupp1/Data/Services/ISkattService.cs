using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication_homework_grupp1.Data.Models;

namespace WebApplication_homework_grupp1.Data.Services
{
    public interface ISkattService
    {
        Task<List<DateDto>> GetDatesAsync();
    }
}

