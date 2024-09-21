using HospitalAppointmentSystem.Model;
using HospitalAppointmentSystem.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalAppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorsService service;

        public DoctorController(IDoctorsService service)
        {
            this.service = service;
        }
        // GET: api/<DoctorController>
        [HttpGet]
        [Route("GetDoctors")]
        public IActionResult Get()
        {
            try
            {
                var model = service.GetAllDoctors();
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


        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        [Route("GetDoctorById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var model = service.GetDoctorsById(id);
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

        // POST api/<DoctorController>
        [HttpPost]
        [Route("AddDoctor")]
        public IActionResult Post([FromBody] Doctors value)
        {
            try
            {
                var model = service.AddDoctors(value);
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

        // PUT api/<DoctorController>/5
        [HttpPut("EditDoctor")]
        public IActionResult Put([FromBody] Doctors value)
        {
            try
            {
                var model = service.UpdateDoctors(value);
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

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        [Route("DeleteDoctor/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = service.DeleteDoctors(id);
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

        [HttpGet("{id}")]
        [Route("GetDoctorInformation/{id}")]
        public IActionResult GetInformationOfDoctors(int id)
        {
            try
            {
                var model = service.GetInformationOfDoctors(id);
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

        [HttpPut("EditDoctorAndUser")]
        public IActionResult UpdateDoctorAndUser([FromBody] UpdateDoctorAndUser value)
        {
            try
            {
                var model = service.UpdateDoctorsAndUser(value.doctors,value.users);
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
