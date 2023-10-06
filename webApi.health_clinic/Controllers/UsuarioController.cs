using Microsoft.AspNetCore.Mvc;
using webApi.health_clinic.Domains;
using webApi.health_clinic.Interfaces;
using webApi.health_clinic.Repositories;

namespace webApi.health_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioRepository _UsuarioRepository;

        public UsuarioController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }


        /// <summary>
        /// Método para atualização de dados do usuário
        /// </summary>
        /// <param name="id"> id do usuário a ser atualizado </param>
        /// <param name="usuarioUpdt"> Objeto com dados atualizados do usuário </param>
        /// <returns> Usuário atualizado </returns>
        [HttpPut]
        public IActionResult Put(Guid id, Usuario usuarioUpdt)
        {
            try
            {
                _UsuarioRepository.Atualizar(id, usuarioUpdt);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Método para buscar o usuário desejado pelo id
        /// </summary>
        /// <param name="id"> id do usuário a ser buscado </param>
        /// <returns> Usuário buscado </returns> 
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                return Ok(_UsuarioRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Método para cadastro do usuário
        /// </summary>
        /// <param name="usuarioCrt"> Objeto com os dados do usuário a ser adicionado </param>
        /// <returns> Usuário novo </returns>
        [HttpPost]
        public IActionResult Post(Usuario usuarioCrt)
        {
            try
            {
                _UsuarioRepository.Cadastrar(usuarioCrt);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Método para deletar usuários
        /// </summary>
        /// <param name="id"> id do usuário a ser deletado </param>
        /// <returns> O usuário é deletado </returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _UsuarioRepository.Delete(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Método para listar usuários cadastrados
        /// </summary>
        /// <returns> Lista de usuários </returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_UsuarioRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
