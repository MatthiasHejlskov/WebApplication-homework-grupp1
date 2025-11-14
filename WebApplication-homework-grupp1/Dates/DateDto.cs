namespace WebApplication_homework_grupp1.Dates
{
    public class DateDto        //Date "data transfer object"     
    {   //specifik data vi vill ha 
        public int Year { get; set; }
        public string Month { get; set; } = null!;  //denna gör att det blir null om det inte finns nån data, annars ger kompilatorn felmeddelande.
        public int Day { get; set; }
        public string TaxableDay { get; set; } = null!;
        
    }
}
