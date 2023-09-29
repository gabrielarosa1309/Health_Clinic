using Microsoft.AspNetCore.Mvc;
using webApi.health_clinic.Domains;
using webApi.health_clinic.Interfaces;
using webApi.health_clinic.Repositories;

namespace webApi.health_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EspecialidadeController : ControllerBase
    {
        private EspecialidadeRepository _EspecialidadeRepository;

        public EspecialidadeController()
        {
            _EspecialidadeRepository = new EspecialidadeRepository();
        }

        [HttpPut]
        public IActionResult Put(Guid id, Especialidade especialidadeUpdt)
        {
            try
            {
                _EspecialidadeRepository.Atualizar(id, especialidadeUpdt);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                return Ok(_EspecialidadeRepository.BuscarPorId(id));
            }
            catch (Exception e)
            { 
                return BadRequest(e.Message); 
            }
        }

        [HttpPost]
        public IActionResult Post(Especialidade especialidadeCrt)
        {
            try
            {
                _EspecialidadeRepository.Cadastrar(especialidadeCrt);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete ("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _EspecialidadeRepository.Delete(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet] 
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_EspecialidadeRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
