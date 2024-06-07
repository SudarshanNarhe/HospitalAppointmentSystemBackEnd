using HospitalAppointmentSystem.Model;
using HospitalAppointmentSystem.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalAppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService service;

        public PatientController(IPatientService service)
        {
            this.service = service;
        }
        // GET: api/<PatientController>
        [HttpGet]
        [Route("GetPatients")]
        public IActionResult Get()
        {
            try
            {
                var model = service.GetAllPatients();
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

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        [Route("GetPatientById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var model = service.GetPatientById(id);
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

        // POST api/<PatientController>
        [HttpPost]
        [Route("AddPatient")]
        public IActionResult Post([FromBody] Patient value)
        {
            try
            {
                var model = service.AddPatient(value);
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

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        [Route("EditPatient/{id}")]
        public IActionResult Put([FromBody] Patient value)
        {
            try
            {
                var model = service.UpdatePatient(value);
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

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        [Route("DeletePatient/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = service.DeletePatient(id);
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
