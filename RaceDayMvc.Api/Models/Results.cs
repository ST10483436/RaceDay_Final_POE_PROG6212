namespace RaceDayMvc.Api.Models
{
    public class Results
    {
        public int ResultId { get; set; }
        public int EventId { get; set; }
        public int ParticipantId { get; set; }
        public int CategoryId { get; set; }
        public string FinishTime { get; set; } = ""; 
        public int Position { get; set; }
    }
}
