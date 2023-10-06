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

        /// <summary>
        /// Método para atualização de dados do tipo de usuário
        /// </summary>
        /// <param name="id"> id do tipo de usuário a ser atualizado </param>
        /// <param name="tiposUsuarioUpdt"> Objeto com dados atualizados do tipo de usuário </param>
        /// <returns> Tipo de usuário atualizado </returns>
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


        /// <summary>
        /// Método para cadastro do tipo de usuário
        /// </summary>
        /// <param name="tipoUsuarioCrt"> Objeto com os dados do tipo de usuário a ser adicionado </param>
        /// <returns> Tipo de usuário novo </returns>
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


        /// <summary>
        /// Método para deletar tipo de usuários
        /// </summary>
        /// <param name="id"> id do tipo de usuário a ser deletado </param>
        /// <returns> O tipo de usuário é deletado </returns>
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


        /// <summary>
        /// Método para listar tipo de usuários cadastrados
        /// </summary>
        /// <returns> Lista de tipo de usuários </returns>
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
