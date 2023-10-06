using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using webApi.health_clinic.Domains;
using webApi.health_clinic.Interfaces;
using webApi.health_clinic.Repositories;

namespace webApi.health_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FeedbackController : ControllerBase
    {
        private FeedbackRepository _FeedbackRepository;

        public FeedbackController()
        {
            _FeedbackRepository = new FeedbackRepository();
        }

        /// <summary>
        /// Método para atualização de dados do feedback
        /// </summary>
        /// <param name="id"> id do feedback a ser atualizado </param>
        /// <param name="feedbackUpdt"> Objeto com dados atualizados do feedback </param>
        /// <returns> feedback atualizado </returns>
        [HttpPut]
        public IActionResult Put(Guid id, Feedback feedbackUpdt)
        {
            try
            {
                _FeedbackRepository.Atualizar(id, feedbackUpdt);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Método para buscar o feedback desejado pelo id
        /// </summary>
        /// <param name="id"> id do feedback a ser buscado </param>
        /// <returns> feedback buscado </returns> 
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                return Ok(_FeedbackRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Método para cadastro do feedback
        /// </summary>
        /// <param name="feedbackCrt"> Objeto com os dados do feedback a ser adicionado </param>
        /// <returns> feedback novo </returns>
        [HttpPost]
        public IActionResult Post(Feedback feedbackCrt)
        {
            try
            {
                _FeedbackRepository.Cadastrar(feedbackCrt);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Método para deletar feedbacks
        /// </summary>
        /// <param name="id"> id do feedback a ser deletado </param>
        /// <returns> O feedback é deletado </returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _FeedbackRepository.Delete(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Método para listar feedbacks cadastrados
        /// </summary>
        /// <returns> Lista de feedbacks </returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_FeedbackRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
 