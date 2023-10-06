using Microsoft.AspNetCore.Mvc;
using webApi.health_clinic.Domains;
using webApi.health_clinic.Interfaces;
using webApi.health_clinic.Repositories;

namespace webApi.health_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClinicaController : ControllerBase
    {
        private ClinicaRepository _ClinicaRepository;

        public ClinicaController()
        {
            _ClinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Método para atualização de dados da clínica
        /// </summary>
        /// <param name="id"> id da clínica a ser atualizada </param>
        /// <param name="clinicaUpdt"> Objeto com dados atualizados da clínica </param>
        /// <returns> Clínica atualizada </returns>
        [HttpPut]
        public IActionResult Put(Guid id, Clinica clinicaUpdt)
        {
            try
            {
                _ClinicaRepository.Atualizar(id, clinicaUpdt);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Método para buscar a clínica desejada pelo id
        /// </summary>
        /// <param name="id"> id da clínica a ser buscada </param>
        /// <returns> Clínica buscada </returns> 
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                return Ok(_ClinicaRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Método para cadastro da clínica
        /// </summary>
        /// <param name="clinicaCrt"> Objeto com os dados da clínica a ser adicionada </param>
        /// <returns> Clínica nova </returns>
        [HttpPost]
        public IActionResult Post(Clinica clinicaCrt)
        {
            try
            {
                _ClinicaRepository.Cadastrar(clinicaCrt);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Método para deletar clínicas
        /// </summary>
        /// <param name="id"> id da clínica a ser deletada </param>
        /// <returns> A clínica é deletada </returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _ClinicaRepository.Delete(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Método para listar clínicas cadastradas
        /// </summary>
        /// <returns> Lista de clínicas </returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_ClinicaRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
