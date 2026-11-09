namespace RaceDayMvc.Api.Models
{// start of the namespace
    public class Participants
    {//start of class
        public int ParticipantId { get; set; }
        public int UsersId { get; set; }
        public string FirstName { get; set; } = ""; 
        public string LastName { get; set; } = ""; 
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = "";
    }//end of class
}
//end of the namespace