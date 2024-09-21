using HospitalAppointmentSystem.Model;
using HospitalAppointmentSystem.Services;
using Microsoft.AspNetCore.Mvc;


namespace HospitalAppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
       private readonly IAppointmentService service;

        public AppointmentController(IAppointmentService service)
        {
            this.service = service;
        }

        // GET: api/<AppointmentController>
        [HttpGet]
        [Route("GetAppointments")]
        public IActionResult Get()
        {
            try
            {
                var model = service.GetAllAppointment();
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

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        [Route("GetAppointmentById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var model = service.GetAppointmentById(id);
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

        // POST api/<AppointmentController>
        [HttpPost]
        [Route("AddAppointment")]
        public IActionResult Post([FromBody] Appointment value)
        {
            try
            {
                var model = service.AddAppointment(value);
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

        // PUT api/<AppointmentController>/5
        [HttpPut("EditAppointment")]
        public IActionResult Put([FromBody] Appointment value)
        {
            try
            {
                var model = service.UpdateAppointment(value);
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

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        [Route("DeleteAppointment/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = service.DeleteAppointment(id);
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
    }
}
