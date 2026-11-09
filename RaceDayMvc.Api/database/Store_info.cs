using System.Data.SqlClient;

namespace RaceDayMvc.Api.database
{// start of the namespace
    public class Store_info
    {// start of Store_info class 
        private string conn = @"Data source=(localdb)\api_guide; database=RACEDAY; Integrated Security=True;";

        public int store_user(string user, string hash, string email, string role)
        {// start ofmethod
            try
            {// start of try
                using (SqlConnection c = new SqlConnection(conn))
                {// using
                    c.Open();
                    var cmd = new SqlCommand($"INSERT INTO Users (Username,Password,Email,Role) VALUES ('{user}','{hash}','{email}','{role}'); SELECT SCOPE_IDENTITY();", c);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }//end of try
            catch { return 0; }
        }//end of the method

        public void store_organiser(int id, string name, string phone)
        {// start of the method
            using (SqlConnection c = new SqlConnection(conn))
            {
                c.Open();
                new SqlCommand($"INSERT INTO Organisers (UsersId,OrganiserName,PhoneNumber) VALUES ({id},'{name}','{phone}')", c).ExecuteNonQuery();
            }
        }//end of method

        public void store_participant(int id, string fn, string ln, string dob, string phone)
        {// start of method
            using (SqlConnection c = new SqlConnection(conn))
            {// start of using
                c.Open();
                new SqlCommand($"INSERT INTO Participants (UsersId,FirstName,LastName,DateOfBirth,PhoneNumber) VALUES ({id},'{fn}','{ln}','{dob}','{phone}')", c).ExecuteNonQuery();
            }//end of using
        }//end of method

        public void store_event(int orgId, string name, string desc, string date, string loc, decimal dist, string type)
        {// start of method
            using (SqlConnection c = new SqlConnection(conn))
            {// start of using
                c.Open();
                new SqlCommand($"INSERT INTO Events (OrganiserId,EventName,Description,EventDate,Location,Distance,EventType) VALUES ({orgId},'{name}','{desc}','{date}','{loc}',{dist},'{type}')", c).ExecuteNonQuery();
            }//end of using
        }//end of method

        public void store_category(int evId, string name, int? min, int? max)
        {// start of method
            using (SqlConnection c = new SqlConnection(conn))
            {// start of using
                c.Open();
                string m1 = min.HasValue ? min.ToString() : "NULL";
                string m2 = max.HasValue ? max.ToString() : "NULL";
                new SqlCommand($"INSERT INTO Categories (EventId,CategoryName,MinAge,MaxAge) VALUES ({evId},'{name}',{m1},{m2})", c).ExecuteNonQuery();
            }//end of using
        }//end of method

        // Enrolment method
        public void store_enrolment(int participantId, int eventId, int categoryId)
        {// start 
            using (SqlConnection c = new SqlConnection(conn))
            {// start of using
                c.Open();
                new SqlCommand($"INSERT INTO EventEnrolments (ParticipantId,EventId,CategoryId,Status) VALUES ({participantId},{eventId},{categoryId},'Registered')", c).ExecuteNonQuery();
            }//end of using
        }//end of method

        // ADDED: Result method
        public void store_result(int eventId, int participantId, int categoryId, string finishTime, int position)
        {// start of method
            using (SqlConnection c = new SqlConnection(conn))
            {// start of using 
                c.Open();
                new SqlCommand($"INSERT INTO Results (EventId,ParticipantId,CategoryId,FinishTime,Position) VALUES ({eventId},{participantId},{categoryId},'{finishTime}',{position})", c).ExecuteNonQuery();
            }//end of using
        }//end of the method


    }//end of Store_Info classs
}//end of thw namespace
