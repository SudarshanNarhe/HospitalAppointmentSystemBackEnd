using HospitalAppointmentSystem.Model;
using HospitalAppointmentSystem.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalAppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthRecordController : ControllerBase
    {
        private readonly IHealthRecordService service;

        public HealthRecordController(IHealthRecordService service)
        {
            this.service = service;
        }
        // GET: api/<HealthRecordController>
        [HttpGet]
        [Route("GetHealthRecords")]
        public IActionResult Get()
        {
            try
            {
                var model = service.GetAllRecords();
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


        // GET api/<HealthRecordController>/5
        [HttpGet("{id}")]
        [Route("GetRecordById/{id}")]
        public IActionResult GetRecordById(int id)
        {
            try
            {
                var model = service.GetRecordById(id);
                if (model != null)
                {
                    return new ObjectResult(model);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // POST api/<HealthRecordController>
        [HttpPost]
        [Route("AddHealthRecord")]
        public IActionResult Post([FromBody] HealthRecord value)
        {
            try
            {
                var model = service.AddHealthRecord(value);
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

        // PUT api/<HealthRecordController>/5
        [HttpPut("EditHealthRecord")]
        public IActionResult Put([FromBody] HealthRecord value)
        {
            try
            {
                var model = service.UpdateHealthRecord(value);
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

        // DELETE api/<HealthRecordController>/5
        [HttpDelete("{id}")]
        [Route("DeleteHealthRecord/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = service.DeleteRecord(id);
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
