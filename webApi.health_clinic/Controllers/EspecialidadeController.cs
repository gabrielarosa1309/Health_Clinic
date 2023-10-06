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

        /// <summary>
        /// Método para atualização de dados da especialidade
        /// </summary>
        /// <param name="id"> id da especialidade a ser atualizada </param>
        /// <param name="especialidadeUpdt"> Objeto com dados atualizados da especialidade </param>
        /// <returns> Especialidade atualizada </returns>
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


        /// <summary>
        /// Método para buscar a especialidade desejada pelo id
        /// </summary>
        /// <param name="id"> id da especialidade a ser buscada </param>
        /// <returns> Especialidade buscada </returns> 
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


        /// <summary>
        /// Método para cadastro de especialidade
        /// </summary>
        /// <param name="especialidadeCrt"> Objeto com os dados da especialidade a ser adicionada </param>
        /// <returns> Especialidade nova </returns>
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


        /// <summary>
        /// Método para deletar especialidades
        /// </summary>
        /// <param name="id"> id da especialidade a ser deletada </param>
        /// <returns> A especialidade é deletada </returns>
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


        /// <summary>
        /// Método para listar especialidades cadastradas
        /// </summary>
        /// <returns> Lista de especialidades </returns>
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
