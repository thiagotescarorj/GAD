using Impacta.GAD.Application.DTOs;
using Impacta.GAD.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Impacta.GAD.WebAPI.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DNSController : Controller
    {
        private readonly IDNSService _dnsService;
        private readonly IClienteService _clienteService;
        public DNSController(
            IDNSService dnsService,
            IClienteService clienteService)
        {
            _dnsService = dnsService;
            _clienteService = clienteService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var dnsList = await _dnsService.GetTodosDNS();
                if (dnsList == null)
                {
                    return NotFound("Nenhum DNS encontrado.");
                }
                else
                {
                    return Ok(dnsList);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar DNSs. Erro: {ex.Message}");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var dns = await _dnsService.GetDNSById(id);
                if (dns == null)
                {
                    return NotFound($"O DNS de ID: {id} não encontrado.");
                }
                else
                {
                    return Ok(dns);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar DNS de ID: {id}. Erro: {ex.Message}");
            }
        }


        [HttpGet("{clienteId}")]
        public async Task<IActionResult> GetByCliente(long clienteId)
        {
            try
            {
                var cliente = await _clienteService.GetClienteById(clienteId);
                if (cliente == null)
                {
                    return NotFound($"Cliente de ID: {clienteId} não encontrado");
                }
                var dns = await _dnsService.GetTodosDNSByCliente(clienteId);
                if (dns == null)
                {
                    return NotFound($"O DNS vinculado ao cliente: {cliente.Nome} não encontrado.");
                }
                else
                {
                    return Ok(dns);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar DNS vinculado ao cliente: {clienteId}. Erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(DNSDTO dns)
        {
            try
            {
                var DNS = await _dnsService.AdicionarDNS(dns);
                if (DNS == null)
                {
                    return NotFound($"Erro ao tentar adcionar dns.");
                }
                else
                {
                    return Ok(dns);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar adcionar DNS. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, DNSDTO model)
        {
            try
            {

                var dns = await _dnsService.GetDNSById(id);
                if (dns == null)
                {
                    return NotFound($"Erro ao tentar adcionar dns.");
                }
                else
                {
                    await _dnsService.AtualizarDNS(id, dns);

                    return Ok(dns);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar atualizar DNS ID:{id}. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                if (await _dnsService.ExcluirDNS(id))
                {
                    return Ok($"DNS ID:{id} deletado");
                }
                else
                {
                    return BadRequest($"DNS ID:{id} não deletado");

                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar excluir DNS ID:{id}. Erro: {ex.Message}");
            }
        }

    }
}
