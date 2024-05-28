using HospitalAppointmentSystem.Model;
using HospitalAppointmentSystem.Services;
using Microsoft.AspNetCore.Mvc;
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

        //Login request
        [HttpGet]  // we use httppost because to use frombody it allows for post not for the get
        [Route("Login/{userName}/{password}")]
        public IActionResult Login(string username, string password)
        { 
            try
            {
                var model = service.LoginUser(username, password);
                if (model != null)
                {
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
    }
}
