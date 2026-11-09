namespace RaceDayMvc.Api.Models
{
    public class Organisers
    {
        public int OrganiserId { get; set; }
        public int UsersId { get; set; }
        public string OrganiserName { get; set; } = ""; 
        public string PhoneNumber { get; set; } = "";
    }
}
