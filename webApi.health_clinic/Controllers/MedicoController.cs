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


        /// <summary>
        /// Método para cadastro do médico
        /// </summary>
        /// <param name="medicoCrt"> Objeto com os dados do médico a ser adicionado </param>
        /// <returns> Médico novo </returns>
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


        /// <summary>
        /// Método para deletar médicos
        /// </summary>
        /// <param name="id"> id do médico a ser deletado </param>
        /// <returns> O médico é deletado </returns>
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
