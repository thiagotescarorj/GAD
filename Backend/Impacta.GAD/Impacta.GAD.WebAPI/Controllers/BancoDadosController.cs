using Impacta.GAD.Application.DTOs;
using Impacta.GAD.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Impacta.GAD.WebAPI.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BancoDadosController : Controller
    {
        private readonly IBancoDadosService _bancoDadosService;
        private readonly IClienteService _clienteService;
        public BancoDadosController(
            IBancoDadosService bancoDadosService,
            IClienteService clienteService)
        {
            _bancoDadosService = bancoDadosService;
            _clienteService = clienteService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var bancoDadosList = await _bancoDadosService.GetTodosBancoDados();
                if (bancoDadosList == null)
                {
                    return NotFound("Nenhum Banco de Dados encontrado.");
                }
                else
                {
                    return Ok(bancoDadosList);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar Banco de Dados. Erro: {ex.Message}");
            }

        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var bancoDados = await _bancoDadosService.GetBancoDadosById(id);
                if (bancoDados == null)
                {
                    return NotFound($"O Banco de Dados de ID: {id} não encontrado.");
                }
                else
                {
                    return Ok(bancoDados);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar BancoDados de ID: {id}. Erro: {ex.Message}");
            }
        }

        //[HttpGet]
        //[Route("GetByNome")]
        //public async Task<IActionResult> GetByNome(string nome)
        //{
        //    try
        //    {
        //        var bancoDados = await _bancoDadosService.GetTodosBancoDadosByNome(nome);
        //        if (bancoDados == null)
        //        {
        //            return NotFound($"O Banco de Dados de nome: {nome} não encontrado.");
        //        }
        //        else
        //        {
        //            return Ok(bancoDados);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        return this.StatusCode(StatusCodes.Status500InternalServerError,
        //                               $"Erro ao tentar recuperar Banco de Dados de nome: {nome}. Erro: {ex.Message}");
        //    }
        //}

        //[HttpGet]
        //[Route("GetByClienteId")]
        //public async Task<IActionResult> GetByCliente(long clienteId)
        //{
        //    try
        //    {
        //        var cliente = await _clienteService.GetClienteById(clienteId);
        //        if (cliente == null)
        //        {
        //            return NotFound($"Cliente de ID: {clienteId} não encontrado");
        //        }
        //        var bancoDados = await _bancoDadosService.GetTodosBancoDadosByCliente(clienteId);
        //        if (bancoDados == null)
        //        {
        //            return NotFound($"O BancoDados vinculado ao cliente: {cliente.Nome} não encontrado.");
        //        }
        //        else
        //        {
        //            return Ok(bancoDados);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        return this.StatusCode(StatusCodes.Status500InternalServerError,
        //                               $"Erro ao tentar recuperar BancoDados vinculado ao cliente: {clienteId}. Erro: {ex.Message}");
        //    }
        //}


        [HttpPost]
        public async Task<IActionResult> Post(BancoDadosDTO bancoDados)
        {
            try
            {
                var BancoDados = await _bancoDadosService.AdicionarBancoDados(bancoDados);
                if (BancoDados == null)
                {
                    return NotFound($"Erro ao tentar adcionar Banco de Dados.");
                }
                else
                {
                    return Ok(bancoDados);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar adcionar Banco de Dados. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, BancoDadosDTO model)
        {
            try
            {

                var bancoDados = await _bancoDadosService.GetBancoDadosById(id);
                if (bancoDados == null)
                {
                    return NotFound($"Erro ao tentar adcionar Banco de Dados.");
                }
                else
                {
                    await _bancoDadosService.AtualizarBancoDados(id, model);

                    return Ok(bancoDados);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar atualizar Banco de Dados ID:{id}. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                if (await _bancoDadosService.ExcluirBancoDados(id))
                {
                    return Ok(new { message = $"Banco de Dados ID:{id} deletado" });
                }
                else
                {
                    return BadRequest($"Banco de Dados ID:{id} não deletado");

                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar excluir Banco de Dados ID:{id}. Erro: {ex.Message}");
            }
        }

    }

}
