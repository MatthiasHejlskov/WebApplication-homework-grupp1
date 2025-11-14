namespace WebApplication_homework_grupp1.Dates
{
    public class ErrorViewDate
    {
        public string? RequestId { get; set; }
        
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
