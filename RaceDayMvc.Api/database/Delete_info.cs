using System.Data.SqlClient;

namespace RaceDayMvc.Api.database
{// start of the namespace
    public class Delete_info
    {// start of Delete info class
        private string conn = @"Data source=(localdb)\api_guide; database=RACEDAY; Integrated Security=True;";

        public void delete_event(int eventId)
        {//start of delete-event method
            using (SqlConnection c = new SqlConnection(conn))
            {// start of using
                c.Open();
                new SqlCommand($"DELETE FROM Events WHERE EventId={eventId}", c).ExecuteNonQuery();
            }//end of using
        }//end of method

        public void delete_category(int categoryId)
        {// start of delete _category method
            using (SqlConnection c = new SqlConnection(conn))
            {// start of using
                c.Open();
                new SqlCommand($"DELETE FROM Categories WHERE CategoryId={categoryId}", c).ExecuteNonQuery();
            }//end of using
        }//end method

        public void delete_enrolment(int enrolmentId)
        {//start of Delete_enrolment method
            using (SqlConnection c = new SqlConnection(conn))
            {// start of using
                c.Open();
                new SqlCommand($"DELETE FROM EventEnrolments WHERE EnrolmentId={enrolmentId}", c).ExecuteNonQuery();
            }//end of using
        }//end of delete_enrolment method

    }//end of the class
}//end of the namespace
