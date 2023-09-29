using Microsoft.AspNetCore.Mvc;
using webApi.health_clinic.Domains;
using webApi.health_clinic.Repositories;

namespace webApi.health_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class TiposUsuarioController : ControllerBase
    {
        private TiposUsuarioRepository _TiposUsuarioRepository;

        public TiposUsuarioController()
        {
            _TiposUsuarioRepository = new TiposUsuarioRepository();
        }

        [HttpPut]
        public IActionResult Put(Guid id, TiposUsuario tiposUsuarioUpdt)
        {
            try
            {
                _TiposUsuarioRepository.Atualizar(id, tiposUsuarioUpdt);

                return NoContent();
            }
            catch (Exception e)
            { 
                return BadRequest(e.Message); 
            }
        }

        [HttpPost]
        public IActionResult Post(TiposUsuario tipoUsuarioCrt)
        {
            try 
            {
                _TiposUsuarioRepository.Cadastrar(tipoUsuarioCrt);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _TiposUsuarioRepository.Delete(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_TiposUsuarioRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }    
}
