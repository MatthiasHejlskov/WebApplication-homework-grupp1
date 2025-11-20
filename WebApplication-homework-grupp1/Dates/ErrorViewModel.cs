namespace WebApplication_homework_grupp1.Dates
{
    public class ErrorViewModel     //lagrar ett fel i loggen om API returnerar ett tomt resultat eller inte svarar
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
 
