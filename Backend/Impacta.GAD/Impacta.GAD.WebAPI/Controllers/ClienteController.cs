using Impacta.GAD.Application.DTOs;
using Impacta.GAD.Application.Interfaces;
using Impacta.GAD.Repository.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Impacta.GAD.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery]PageParams pageParams)
        {
            try
            {
                var clientes = await _clienteService.GetTodosClientes(pageParams);
                if (clientes == null)
                {
                    return NotFound("Nenhum Cliente encontrado.");
                }
                else
                {
                    return Ok(clientes);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar Clientes. Erro: {ex.Message}");
            }

        }

        [HttpGet("{id:double}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var cliente = await _clienteService.GetClienteById(id);
                if (cliente == null)
                {
                    return NotFound($"O Cliente de ID: {id} não encontrado.");
                }
                else
                {
                    return Ok(cliente);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar Cliente de ID: {id}. Erro: {ex.Message}");
            }
        }

        [HttpGet("{nome:alpha}")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                var cliente = await _clienteService.GetTodosClientesByNome(nome);
                if (cliente == null)
                {
                    return NotFound($"O Cliente de nome: {nome} não encontrado.");
                }
                else
                {
                    return Ok(cliente);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar Cliente de nome: {nome}. Erro: {ex.Message}");
            }
        }



        [HttpPost]
        public async Task<IActionResult> Post(ClienteDTO cliente)
        {
            try
            {
                var Cliente = await _clienteService.AdicionarCliente(cliente);
                if (Cliente == null)
                {
                    return NotFound($"Erro ao tentar adcionar cliente.");
                }
                else
                {
                    return Ok(cliente);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar adcionar Cliente. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, ClienteDTO model)
        {
            try
            {

                var cliente = await _clienteService.GetClienteById(id);
                if (cliente == null)
                {
                    return NotFound($"Erro ao tentar adcionar cliente.");
                }
                else
                {
                    model.Id = cliente.Id;
                    await _clienteService.AtualizarCliente(id, model);

                    return Ok(cliente);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar atualizar Cliente ID:{id}. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                if (await _clienteService.ExcluirCliente(id))
                {
                    return Ok($"Cliente ID:{id} deletado");
                }
                else
                {
                    return BadRequest($"Cliente ID:{id} não deletado");

                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar excluir Cliente ID:{id}. Erro: {ex.Message}");
            }
        }

    }
}
