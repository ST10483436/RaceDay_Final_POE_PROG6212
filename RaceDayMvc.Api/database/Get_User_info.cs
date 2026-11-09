using Microsoft.Extensions.Logging;
using RaceDayMvc.Api.Models;
using System.Data.SqlClient;

namespace RaceDayMvc.Api.database
{// start of the namespace
    public class Get_User_info
    {// start of class Get_user_info
        private string conn = @"Data source=(localdb)\api_guide; database=RACEDAY; Integrated Security=True;";

        public Users? get_user(string email)
        {// start of method
            using (SqlConnection c = new SqlConnection(conn))
            {// start of using
                c.Open();
                var r = new SqlCommand($"SELECT * FROM Users WHERE Email='{email}'", c).ExecuteReader();
                if (r.Read())
                {// start of if
                    return new Users { UsersId = (int)r["UsersId"], Username = r["Username"].ToString()!, Password = r["Password"].ToString()!, Email = r["Email"].ToString()!, Role = r["Role"].ToString()! };
                }//end of if
            }//end of using
            return null;
        }//end of method

        public Organisers? get_organiser(int userId)
        {// start of method
            using (SqlConnection c = new SqlConnection(conn))
            {//start of using 
                c.Open();
                var r = new SqlCommand($"SELECT * FROM Organisers WHERE UsersId={userId}", c).ExecuteReader();
                if (r.Read())
                {// start of if statement
                    return new Organisers { OrganiserId = (int)r["OrganiserId"], UsersId = (int)r["UsersId"], OrganiserName = r["OrganiserName"].ToString()!, PhoneNumber = r["PhoneNumber"].ToString()! };
                }//end of if statement
            }//end of using
            return null;
        }//end of method

        public Participants? get_participant(int userId)
        {// start of method
            using (SqlConnection c = new SqlConnection(conn))
            {// start of using
                c.Open();
                var r = new SqlCommand($"SELECT * FROM Participants WHERE UsersId={userId}", c).ExecuteReader();
                if (r.Read())
                {// start of if statement
                    return new Participants { ParticipantId = (int)r["ParticipantId"], UsersId = (int)r["UsersId"], FirstName = r["FirstName"].ToString()!, LastName = r["LastName"].ToString()!, DateOfBirth = (DateTime)r["DateOfBirth"], PhoneNumber = r["PhoneNumber"].ToString()! };
                }//end of if statement
            }//end of using 
            return null;
        }//end of method

        public List<Events> get_events()
        {// start of method
            var list = new List<Events>();
            using (SqlConnection c = new SqlConnection(conn))
            {//start of using
                c.Open();
                var r = new SqlCommand("SELECT * FROM Events", c).ExecuteReader();
                while (r.Read())
                {//start of while
                    list.Add(new Events { EventId = (int)r["EventId"], OrganiserId = (int)r["OrganiserId"], EventName = r["EventName"].ToString()!, Description = r["Description"]?.ToString(), EventDate = (DateTime)r["EventDate"], Location = r["Location"].ToString()!, Distance = (decimal)r["Distance"], EventType = r["EventType"].ToString()!, ImageUrl = r["ImageUrl"]?.ToString() });
                }//end of while
            }//end of using
            return list;
        }//end of method

        public List<Categories> get_categories(int eventId)
        {// start of method
            var list = new List<Categories>();
            using (SqlConnection c = new SqlConnection(conn))
            {// start of using
                c.Open();
                var r = new SqlCommand($"SELECT * FROM Categories WHERE EventId={eventId}", c).ExecuteReader();
                while (r.Read())
                {//start of while statement
                    list.Add(new Categories
                    {
                        CategoryId = (int)r["CategoryId"],
                        EventId = (int)r["EventId"],
                        CategoryName = r["CategoryName"].ToString()!,
                        MinAge = r["MinAge"] == DBNull.Value ? null : (int?)r["MinAge"],
                        MaxAge = r["MaxAge"] == DBNull.Value ? null : (int?)r["MaxAge"]
                    });
                }//end of while statement
            }//end of using
            return list;
        }//end of method

    }//end of Get_user_info class
}//end of the namespace
