using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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
    public class ConsultaController : ControllerBase
    {
        private ConsultaRepository _ConsultaRepository;

        public ConsultaController()
        {
            _ConsultaRepository = new ConsultaRepository();
        }

        [HttpPut]
        public IActionResult Put(Guid id, Consulta consultaUpdt)
        {
            try
            {
                _ConsultaRepository.Atualizar(id, consultaUpdt);

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
                return Ok(_ConsultaRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Consulta consultaCrt)
        {
            try
            {
                _ConsultaRepository.Cadastrar(consultaCrt);

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
                _ConsultaRepository.Delete(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarPaciente/{id}")]
        public IActionResult GetPaciente(Guid id)
        {
            try
            {
                return Ok(_ConsultaRepository.ListarDePaciente(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarMedico/{id}")]
        public IActionResult GetMedico(Guid id)
        {
            try
            {
                return Ok(_ConsultaRepository.ListarDeMedico(id));
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
                return Ok(_ConsultaRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
