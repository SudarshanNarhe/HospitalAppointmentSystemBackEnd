using HospitalAppointmentSystem.Model;
using HospitalAppointmentSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private IUserRoleService service;

        public UserRoleController(IUserRoleService service)
        {
            this.service = service;
        }

        // GET: api/<UserRoleController>
        [HttpGet]
        [Route("GetUserRoles")]
        public IActionResult Get()
        {
            try
            {
                var model = service.GetAllUserRole();
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

        // GET api/<UserRoleController>/5
        [HttpGet("{id}")]
        [Route("GetUserRoleById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var model = service.GetUserRoleById(id);
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

        // POST api/<UserRoleController>
        [HttpPost]
        [Route("AddUserRole")]
        public IActionResult Post([FromBody] UserRole value)
        {
            try
            {
                var model = service.AddUserRole(value);
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

        // PUT api/<UserRoleController>/5
        [HttpPut("{id}")]
        [Route("EditUserRole/{id}")]
        public IActionResult Put([FromBody] UserRole value)
        {
            try
            {
                var model = service.UpdateUserRole(value);
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

        // DELETE api/<UserRoleController>/5
        [HttpDelete("{id}")]
        [Route("DeleteUserRole/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = service.DeleteUserRole(id);
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
