using HospitalAppointmentSystem.Model;
using HospitalAppointmentSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace HospitalAppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
 
        public UserController(IUserService service)
        {
            this.service = service;
        }

        // GET: api/<UserController>
        [HttpGet]
        [Route("GetUsers")]
        public IActionResult Get()
        {
            try
            {
                var model = service.GetUsers();
                if (model != null)
                {
                    Console.WriteLine(model);
                    return new ObjectResult(model);
                }
                else
                    return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [Route("GetUserById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var model = service.GetUserById(id);
                if (model != null)
                {
                    return new ObjectResult(model);
                }
                else
                    return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        [Route("AddUser")]
        public IActionResult Post([FromBody] Users value)
        {
            try
            {
                var model = service.AddUser(value);
                Console.WriteLine(value);
                if (model >= 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                    return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [Route("EditUser/{id}")]
        public IActionResult Put([FromBody] Users value)
        {
            try
            {
                var model = service.UpdateUser(value);
                if (model >= 1)
                    return StatusCode(StatusCodes.Status200OK);
                else
                    return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [Route("DeleteUser/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = service.DeleteUser(id);
                if (model >= 1)
                    return StatusCode(StatusCodes.Status200OK);
                else
                    return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{name}")]
        [Route("GetUserByName/{name}")]
        public IActionResult GetUserByName(string name)
        {
            try
            {
                var model = service.GetUserByName(name);
                if (model != null)
                {
                    Console.WriteLine(model);
                    return new ObjectResult(model);
                }
                else
                    return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        //Login request
        [HttpPost]  // we use httppost because to use frombody it allows for post not for the get
        [Route("Login")]
        public IActionResult Login([FromBody]Users user)
        { 
            try
            {
                var model = service.LoginUser(user);
                
                if (model != null)
                {
                   /* string mail = model.Email;
                    HttpContext.Session.SetString("username", mail);*/
                    return new ObjectResult(model);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("SetSession")]
        public IActionResult SetSession([FromBody]Users user) 
        {
            if(user != null)
            {
                // Serialize user object to store in session
                var serializedUser = System.Text.Json.JsonSerializer.Serialize(user);

                // Store serialized user object in session
                HttpContext.Session.SetString("user", serializedUser);
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return StatusCode(StatusCodes.Status406NotAcceptable);
            }
        }

        [HttpGet]
        [Route("GetSession")]
        public IActionResult GetSession()
        {
            try
            {
                var serializedUser = HttpContext.Session.GetString("user");
                if (string.IsNullOrEmpty(serializedUser))
                {
                    return Unauthorized("No active session");
                }

                // Deserialize JSON string to Users object
                var user = JsonSerializer.Deserialize<Users>(serializedUser);

                return Ok(user); // Return deserialized object
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete]
        [Route("Logout")]
        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.Clear();
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
          
        }
    }
}
