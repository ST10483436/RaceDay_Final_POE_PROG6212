namespace RaceDayMvc.Api.Models
{
    public class EventEnrolments
    {
        public int EnrolmentId { get; set; }
        public int ParticipantId { get; set; }
        public int EventId { get; set; }
        public int CategoryId { get; set; }
        public string Status { get; set; } = "Registered";
    }
}
