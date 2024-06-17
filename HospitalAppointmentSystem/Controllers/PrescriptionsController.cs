using HospitalAppointmentSystem.Model;
using HospitalAppointmentSystem.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalAppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService service;

        public PrescriptionsController(IPrescriptionService service)
        {
            this.service = service;
        }
        // GET: api/<PrescriptionsController>
        [HttpGet]
        [Route("GetAllPrescriptions")]
        public IActionResult Get()
        {
            try
            {
                var model = service.GetAllPrecriptions();
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

        // GET api/<PrescriptionsController>/5
        [HttpGet("{id}")]
        [Route("GetPrescriptionById/{id}")]
        public IActionResult GetPrescriptionById(int id)
        {
            try
            {
                var model = service.GetPrescriptionById(id);
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

        // POST api/<PrescriptionsController>
        [HttpPost]
        [Route("AddPrescription")]
        public IActionResult Post([FromBody] Prescriptions value)
        {
            try
            {
                var model = service.AddPrescription(value);
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

        // PUT api/<PrescriptionsController>/5
        [HttpPut("EditPrescriptions")]
        public IActionResult Put([FromBody] Prescriptions value)
        {
            try
            {
                var model = service.UpdatePrescription(value);
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

        // DELETE api/<PrescriptionsController>/5
        [HttpDelete("{id}")]
        [Route("DeletePrescription/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = service.DeletePrescription(id);
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
