using Microsoft.AspNetCore.Mvc;
using RaceDayMvc.Api.database;

namespace RaceDayMvc.Api.Controllers
{// start of the namespace
    [Route("api")]
    [ApiController]
    public class EnrolmentsController : ControllerBase
    {// start of class
        private int? UserId => HttpContext.Session.GetInt32("UserId");
        private string? Role => HttpContext.Session.GetString("UserRole");

        [HttpPost("events/{evId}/enrolments")]
        public IActionResult Enrol(int evId, int categoryId)
        {// start of enrolment method
            try
            {// start of try
                if (UserId == null || Role != "Participant")
                    return StatusCode(403, "Only Participants can enrol");

                var p = new Get_User_info().get_participant(UserId.Value);
                if (p == null) return BadRequest("Participant profile not found");

                new Store_info().store_enrolment(p.ParticipantId, evId, categoryId);

                return StatusCode(201, new { message = "Enrolled successfully" });
            }//end of try
            catch (Exception ex)
            {// catch statement
                return StatusCode(500, "Error: " + ex.Message);
            }//end 
        }//end od metod

        [HttpPost("events/{evId}/results")]
        public IActionResult Result(int evId, int participantId, int categoryId, string finishTime, int position)
        {// start of Result method
            try
            {// start of try
                if (UserId == null || Role != "Organiser")
                    return StatusCode(403, "Only Organisers can record results");

                new Store_info().store_result(evId, participantId, categoryId, finishTime, position);

                return StatusCode(201, new { message = "Result recorded successfully" });
            }//end of try
            catch (Exception ex)
            {//catch statement
                return StatusCode(500, "Error: " + ex.Message);
            }//end of catch statement
        }//end of Result method
    }//end of Class

}//end of the namespace
