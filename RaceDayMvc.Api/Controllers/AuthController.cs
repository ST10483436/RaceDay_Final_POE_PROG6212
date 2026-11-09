using Microsoft.AspNetCore.Mvc;
using RaceDayMvc.Api.database;

namespace RaceDayMvc.Api.Controllers
{// start of the namespace
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {// start of AuthController class
        [HttpPost("register")]
        public IActionResult Register(string fullName, string email, string password, string role, string? phoneNumber, DateTime? dateOfBirth)
        {// start of IactionResult Register method
            try
            {// try
                var getter = new Get_User_info();
                if (getter.get_user(email) != null) return Conflict("Email already exists");

                var storer = new Store_info();
                string hash = BCrypt.Net.BCrypt.HashPassword(password);
                int id = storer.store_user(email.Split('@')[0], hash, email, role);

                if (role == "Organiser")
                {// if statements
                    storer.store_organiser(id, fullName, phoneNumber ?? "");
                }//end 
                else
                {// start of else
                    var p = fullName.Split(' ');
                    storer.store_participant(id, p[0], p.Length > 1 ? p[1] : "", (dateOfBirth ?? DateTime.Now.AddYears(-20)).ToString("yyyy-MM-dd"), phoneNumber ?? "");
                }//end of else statement


                //return statement
                return StatusCode(201, new { message = "Registered", userId = id, role });
            }
            catch (Exception ex)
            {// start of catch statement
                return StatusCode(500, "Error: " + ex.Message);
            }//end 
        }//end of the method

        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {// start of Login method
            try
            {// try
                var user = new Get_User_info().get_user(email);
                if (user == null)
                    return Unauthorized("User not found");

                bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, user.Password);

                if (!isPasswordCorrect)
                    return Unauthorized("Invalid password");

                HttpContext.Session.SetInt32("UserId", user.UsersId);
                HttpContext.Session.SetString("UserRole", user.Role);

                return Ok(new { message = "Logged in", userId = user.UsersId, role = user.Role });
            }//end 
            catch (Exception ex)
            {//catch
                return StatusCode(500, "Error: " + ex.Message);
            }
        }//end of Login method

        [HttpPost("logout")]
        public IActionResult Logout()
        {// start of Logout method
            HttpContext.Session.Clear();
            return Ok(new { message = "Logged out" });
        }//end of logout method
    }//end of class


}//end of the namespace
