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


        /// <summary>
        /// Método para atualização de dados da consulta
        /// </summary>
        /// <param name="id"> id da consulta a ser atualizada </param>
        /// <param name="consultaUpdt"> Objeto com dados atualizados da consulta </param>
        /// <returns> Consulta atualizada </returns>
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


        /// <summary>
        /// Método para buscar a consulta desejada pelo id
        /// </summary>
        /// <param name="id"> id da consulta a ser buscada </param>
        /// <returns> Consulta buscada </returns>
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


        /// <summary>
        /// Método para cadastro da consulta
        /// </summary>
        /// <param name="consultaCrt"> Objeto com os dados da consulta a ser adicionada </param>
        /// <returns> Consulta nova </returns>
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


        /// <summary>
        /// Método para deletar consultas
        /// </summary>
        /// <param name="id"> id da consulta a ser deletada </param>
        /// <returns> A consulta é deletada </returns>
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


        /// <summary>
        /// Método para listar de forma filtrada todas as consultas de determinado paciente
        /// </summary>
        /// <param name="id"> id do usuário de quem serão listadas suas consutas </param>
        /// <returns> Lista de consultas do paciente espcificado </returns>
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


        /// <summary>
        /// Método para listar de forma filtrada todas as consultas de determinado médico
        /// </summary>
        /// <param name="id"> id do médico de quem serão listadas suas consutas </param>
        /// <returns> Lista de consultas do médico espcificado </returns>
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


        /// <summary>
        /// Método para listar consultas
        /// </summary>
        /// <returns> Lista de consultas </returns>
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
