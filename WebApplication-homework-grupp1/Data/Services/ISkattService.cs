using WebApplication_homework_grupp1.Dates;
namespace WebApplication_homework_grupp1.Data.Services

{
    public interface ISkattService      //interface som tvingar klasser att skapa en lista med datumen
    {
        Task<List<DateDto>> GetDates();


    }
}
