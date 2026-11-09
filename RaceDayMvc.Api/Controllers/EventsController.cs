using Microsoft.AspNetCore.Mvc;
using RaceDayMvc.Api.database;
using RaceDayMvc.Api.Models;

namespace RaceDayMvc.Api.Controllers
{// start of the namespace
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {// start of EventsConroller class
        private int? UserId => HttpContext.Session.GetInt32("UserId");
        private string? Role => HttpContext.Session.GetString("UserRole");

        [HttpGet]
        public IActionResult Get()
        {// start of get Method
            try
            {//try
                return Ok(new Get_User_info().get_events());
            }//end of try
            catch (Exception ex)
            {//start of catch
                return StatusCode(500, "Error: " + ex.Message);
            }//end of catch
        }//end of get method

        [HttpGet("{id}/categories")]
        public IActionResult GetCats(int id)
        {// start of getCategories method
            try
            {// try
                return Ok(new Get_User_info().get_categories(id));
            }//end
            catch (Exception ex)
            {//start of Catch
                return StatusCode(500, "Error: " + ex.Message);
            }//end of Catch
        }//end of getCategories method

        [HttpPost]
        public IActionResult Create(string name, string? description, DateTime date, string location, decimal distance, string eventType)
        {// start of Create method
            try
            {//try
                if (UserId == null || Role != "Organiser") return StatusCode(403, "Only Organisers can create events");

                var org = new Get_User_info().get_organiser(UserId.Value);
                new Store_info().store_event(org!.OrganiserId, name, description ?? "", date.ToString("yyyy-MM-dd"), location, distance, eventType);

                return StatusCode(201, new { message = "Event created" });
            }//end of try
            catch (Exception ex)
            {//start of CATCH statement
                return StatusCode(500, "Error: " + ex.Message);
            }//end of catch Statement
        }//end of create method

        [HttpPost("{id}/categories")]
        public IActionResult CreateCat(int id, string categoryName, int? minAge, int? maxAge)
        {// start of create Categories method
            try
            {// start of try
                if (UserId == null || Role != "Organiser") return StatusCode(403, "Only Organisers can create categories");

                new Store_info().store_category(id, categoryName, minAge, maxAge);
                return StatusCode(201, new { message = "Category created" });
            }//end of try
            catch (Exception ex)
            {//start of catch statement
                return StatusCode(500, "Error: " + ex.Message);
            }//end of catch statement
        }//end of Create Categories method
    }//end of class


}//end of the namespace
