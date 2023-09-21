using Impacta.GAD.Application.DTOs;
using Impacta.GAD.Application.Interfaces;
using Impacta.GAD.WebAPI.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Impacta.GAD.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController: ControllerBase
    {
        private readonly IProjetoService _projetoService;
        private readonly IChamadoService _chamadoService;
        private readonly IUsuarioService _usuarioService;

        public ProjetoController(IProjetoService ProjetoService,
                                      IChamadoService chamadoService,
                                      IUsuarioService usuarioService) {
            _usuarioService = usuarioService;
            _projetoService = ProjetoService;
            _chamadoService = chamadoService;
        }

        [HttpGet("chamado/{chamadoId}")]
        public async Task<IActionResult> GetByChamado(long chamadoId) {
            try {
                if (!(await AutorChamado(chamadoId)))
                    return Unauthorized();

                var projeto = await _projetoService.GetAllByChamadoIdAsync(chamadoId);
                if (projeto == null) return NoContent();

                return Ok(projeto);
            } catch (Exception ex) {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Projeto por Chamado. Erro: {ex.Message}");
            }
        }

        [HttpGet("usuario")]
        public async Task<IActionResult> GetByUsuario() {
            try {
                var usuario = await _usuarioService.GetUsuarioByUserIdAsync(User.GetUserId());
                if (usuario == null) return Unauthorized();

                var projeto = await _projetoService.GetAllByUsuarioIdAsync(usuario.Id);
                if (projeto == null) return NoContent();

                return Ok(projeto);
            } catch (Exception ex) {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Projeto por Usuario. Erro: {ex.Message}");
            }
        }

        [HttpPut("chamado/{chamadoId}")]
        public async Task<IActionResult> SaveByChamado(long chamadoId, ProjetoDTO[] models) {
            try {
                if (!(await AutorChamado(chamadoId)))
                    return Unauthorized();

                var projeto = await _projetoService.SaveByChamado(chamadoId, models);
                if (projeto == null) return NoContent();

                return Ok(projeto);
            } catch (Exception ex) {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar salvar Projeto por Chamado. Erro: {ex.Message}");
            }
        }

        [HttpPut("usuario")]
        public async Task<IActionResult> SaveByUsuario(ProjetoDTO[] models) {
            try {
                var usuario = await _usuarioService.GetUsuarioByUserIdAsync(User.GetUserId());
                if (usuario == null) return Unauthorized();

                var projeto = await _projetoService.SaveByUsuario(usuario.Id, models);
                if (projeto == null) return NoContent();

                return Ok(projeto);
            } catch (Exception ex) {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar salvar Projeto por Usuario. Erro: {ex.Message}");
            }
        }

        [HttpDelete("chamado/{chamadoId}/{projetoId}")]
        public async Task<IActionResult> DeleteByChamado(long chamadoId, long projetoId) {
            try {
                if (!(await AutorChamado(chamadoId)))
                    return Unauthorized();

                var Projeto = await _projetoService.GetProjetoChamadoByIdsAsync(chamadoId, projetoId);
                if (Projeto == null) return NoContent();

                return await _projetoService.DeleteByChamado(chamadoId, projetoId)
                       ? Ok(new { message = "Projeto Deletada" })
                       : throw new Exception("Ocorreu um problem não específico ao tentar deletar Projeto por Chamado.");
            } catch (Exception ex) {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar Projeto por Chamado. Erro: {ex.Message}");
            }
        }

        [HttpDelete("usuario/{projetoId}")]
        public async Task<IActionResult> DeleteByUsuario(long projetoId) {
            try {
                var usuario = await _usuarioService.GetUsuarioByUserIdAsync(User.GetUserId());
                if (usuario == null) return Unauthorized();

                var Projeto = await _projetoService.GetProjetoUsuarioByIdsAsync(usuario.Id, projetoId);
                if (Projeto == null) return NoContent();

                return await _projetoService.DeleteByUsuario(usuario.Id, projetoId)
                       ? Ok(new { message = "Projeto Deletada" })
                       : throw new Exception("Ocorreu um problem não específico ao tentar deletar Projeto por Usuario.");
            } catch (Exception ex) {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar Projeto por Usuario. Erro: {ex.Message}");
            }
        }

        [NonAction]
        private async Task<bool> AutorChamado(long chamadoId) {
            var chamado = await _chamadoService.GetChamadoByIdAsync(User.GetUserId(), chamadoId, false);
            if (chamado == null) return false;

            return true;
        }
    }
}
