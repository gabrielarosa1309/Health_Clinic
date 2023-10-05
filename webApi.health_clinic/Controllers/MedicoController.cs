using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using webApi.health_clinic.Domains;
using webApi.health_clinic.Interfaces;
using webApi.health_clinic.Repositories;

namespace webApi.health_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicoController : ControllerBase
    {
        private MedicoRepository _MedicoRepository;

        public MedicoController()
        {
            _MedicoRepository = new MedicoRepository();
        }


        [HttpPost]
        [Authorize(Roles = "Adm")]
        public IActionResult Post(Medico medicoCrt)
        {
            try
            {
                _MedicoRepository.Cadastrar(medicoCrt);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Adm")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _MedicoRepository.Delete(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
