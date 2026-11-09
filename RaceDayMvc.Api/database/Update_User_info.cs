using System.Data.SqlClient;

namespace RaceDayMvc.Api.database
{// start of the namespace
    public class Update_User_info
    {// start of update_user_info class
        private string conn = @"Data source=(localdb)\api_guide; database=RACEDAY; Integrated Security=True;";

        public void update_user_email(int userId, string email)
        {// start of update_user_email
            using (SqlConnection c = new SqlConnection(conn))
            {//start of using
                c.Open();
                new SqlCommand($"UPDATE Users SET Email='{email}', Username='{email.Split('@')[0]}' WHERE UsersId={userId}", c).ExecuteNonQuery();
            }//endof using
        }//end of update-user_email method

        public void update_organiser(int userId, string name, string phone)
        {// start of update_organiser
            using (SqlConnection c = new SqlConnection(conn))
            {
                c.Open();
                new SqlCommand($"UPDATE Organisers SET OrganiserName='{name}', PhoneNumber='{phone}' WHERE UsersId={userId}", c).ExecuteNonQuery();
            }//end 
        }//end of update-organiser method

        public void update_participant(int userId, string fn, string ln, string phone)
        {// start of Update_participant method
            using (SqlConnection c = new SqlConnection(conn))
            {
                c.Open();
                new SqlCommand($"UPDATE Participants SET FirstName='{fn}', LastName='{ln}', PhoneNumber='{phone}' WHERE UsersId={userId}", c).ExecuteNonQuery();
            }//end 
        }//end of Update_participant method

        public void update_event(int eventId, string name, string desc, string date, string loc, decimal dist, string type)
        {// start of update_event method
            using (SqlConnection c = new SqlConnection(conn))
            {//using
                c.Open();
                new SqlCommand($"UPDATE Events SET EventName='{name}', Description='{desc}', EventDate='{date}', Location='{loc}', Distance={dist}, EventType='{type}' WHERE EventId={eventId}", c).ExecuteNonQuery();
            }//end 
        }//end of update-event method

    }//end of the Upsate_user_info class
}// end of the namespace
