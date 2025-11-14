namespace WebApplication_homework_grupp1.Dates
{
    public class DateResponse
    {   //tar datan från API och lägger det i en lista.
        public int Count { get; set; }
        public string Message { get; set; } = null!;
        public List<DateDto>? Results { get; set; }
    }
}
