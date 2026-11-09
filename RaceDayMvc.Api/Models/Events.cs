namespace RaceDayMvc.Api.Models
{
    public class Events
    {
        public int EventId { get; set; }
        public int OrganiserId { get; set; }
        public string EventName { get; set; } = ""; 
        public string? Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; } = ""; 
        public decimal Distance { get; set; }
        public string EventType { get; set; } = ""; 
        public string? ImageUrl { get; set; }
    }
}
