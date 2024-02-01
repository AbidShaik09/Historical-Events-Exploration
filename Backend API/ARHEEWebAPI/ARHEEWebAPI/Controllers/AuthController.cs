using ARHEEWebAPI.Appdbcontext;
using ARHEEWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Net;

namespace ARHEEWebAPI.Controllers
{

    
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ApplicationDbContext _db;
        public AuthController(ApplicationDbContext db)
        {
            _db = db;
            
        }

        /*
         When User Tries to login using his/her username and password, the httpGET request is called and 
        here: 
            1. username & Password is Verified
            2. if user is valid:
                    -> Authentication Token Is Generated
                else :
                    -> Invalid Login is returned
         */

        [HttpGet("login")]
        public IActionResult Login(string username , string password)
        {
            if(username == "" || password == "" || username == null || password == null)
            {
                return Unauthorized("username/password can't be null");

            }


            var entry = _db.userDetails.FirstOrDefault(e=>(e.username == username && e.password == password));
            if (entry == null)
            {
                return Unauthorized("Invalid username/password");
            }

            
            TokenAuthenticator tokenAuthenticator = new TokenAuthenticator();
            string accessToken = tokenAuthenticator.GenerateAuthToken(username);

            return Ok(accessToken);
        }



        /*
         When user registers his account this method is called. 
         */

        [HttpPost("Register")]
        public IActionResult RegisterNewUser([FromBody] UserDetails userDetails)
        {
            var entry = _db.userDetails.FirstOrDefault(u => (u.username == userDetails.username));
            if(entry != null)
            {
                return Conflict("username Already Exists");
            }
            entry = _db.userDetails.FirstOrDefault(u => (u.email == userDetails.email));
            if (entry != null)
            {
                return Conflict("Email is Already Registered");
            }
            try
            {
                _db.userDetails.Add(userDetails);
                _db.SaveChanges();
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
            return Ok("User Registered");
        }



        /*
         
         This HttpGet is called when user visits profile scene  
         
         */


        [HttpGet("Details")]
        public IActionResult getUserDetails(string accessToken)
        {

            if (!isTokenValid(accessToken))
            {
                return Unauthorized("Access Denied , Login Again");
            }
            TokenAuthenticator tokenAuthenticator = new TokenAuthenticator();
            string username= tokenAuthenticator.getUserNameFromAccessToken(accessToken);
            UserDetails user =_db.userDetails.FirstOrDefault(e=>(e.username== username));
            if (user == null) {
                return StatusCode(500);
            }
            user.password = "***********";
            return Ok(user);

        }

        [HttpGet("/isValidToken")]
        public bool isTokenValid(string token)
        {
            string accessToken = token;
            TokenAuthenticator a = new TokenAuthenticator();
            if (a.Authenticate(accessToken))
            {
                return true;
            }
            else
            {
                return false;
            }
        }









    }
}
