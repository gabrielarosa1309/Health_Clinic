using Microsoft.AspNetCore.Mvc;
using webApi.health_clinic.Domains;
using webApi.health_clinic.Interfaces;
using webApi.health_clinic.Repositories;

namespace webApi.health_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PacienteController : ControllerBase
    {
        private PacienteRepository _PacienteRepository;

        public PacienteController()
        {
            _PacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// Método para cadastro do paciente
        /// </summary>
        /// <param name="pacienteCrt"> Objeto com os dados do paciente a ser adicionado </param>
        /// <returns> Paciente novo </returns>
        [HttpPost]
        public IActionResult Post(Paciente pacienteCrt)
        {
            try
            {
                _PacienteRepository.Cadastrar(pacienteCrt);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Método para deletar pacientes
        /// </summary>
        /// <param name="id"> id do paciente a ser deletado </param>
        /// <returns> O paciente é deletado </returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _PacienteRepository.Delete(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
