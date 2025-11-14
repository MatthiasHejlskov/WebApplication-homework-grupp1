namespace WebApplication_homework_grupp1.Data.Models
{
    public class DateDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int TaxableDay { get; set; } // 0 = no tax, >0 = taxed
    }
}
