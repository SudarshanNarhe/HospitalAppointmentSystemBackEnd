using HospitalAppointmentSystem.Model;
using HospitalAppointmentSystem.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalAppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecilityController : ControllerBase
    {
        private readonly ISpecilityService service;

        public SpecilityController(ISpecilityService service)
        {
            this.service = service;
        }
        // GET: api/<SpecilityController>
        [HttpGet]
        [Route("GetSpecility")]
        public IActionResult Get()
        {
            try
            {
                var model = service.GetSpecilities();
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

        // GET api/<SpecilityController>/5
        [HttpGet("{id}")]
        [Route("GetSpecilityById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var model = service.GetSpecilityById(id);
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

        // POST api/<SpecilityController>
        [HttpPost]
        [Route("AddSpecility")]
        public IActionResult Post([FromBody] Specialty value)
        {
            try
            {
                var model = service.AddSpeciality(value);
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

        // PUT api/<SpecilityController>/5
        [HttpPut("{id}")]
        [Route("EditSpecility/{id}")]
        public IActionResult Put([FromBody] Specialty value)
        {
            try
            {
                var model = service.UpdateSpeciality(value);
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

        // DELETE api/<SpecilityController>/5
        [HttpDelete("{id}")]
        [Route("DeleteSpecility/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = service.DeleteSpeciality(id);
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
