using HospitalAppointmentSystem.Model;
using HospitalAppointmentSystem.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalAppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService service;

        public StatusController(IStatusService service)
        {
            this.service = service;
        }

        // GET: api/<StatusController>
        [HttpGet]
        [Route("GetStatus")]
        public IActionResult Get()
        {
            try
            {
                var model = service.GetAllStatus();
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

        // GET api/<StatusController>/5
        [HttpGet("{id}")]
        [Route("GetStatusById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var model = service.GetStatusById(id);
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

        // POST api/<StatusController>
        [HttpPost]
        [Route("AddStatus")]
        public IActionResult Post([FromBody] Status value)
        {
            try
            {
                var model = service.AddStatus(value);
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

        // PUT api/<StatusController>/5
        [HttpPut]
        [Route("EditStatus")]
        public IActionResult Put([FromBody] Status value)
        {
            try
            {
                var model = service.UpdateStatus(value);
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

        // DELETE api/<StatusController>/5
        [HttpDelete("{id}")]
        [Route("DeleteStatus/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = service.DeleteStatus(id);
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
