using Impacta.GAD.Application.DTOs;
using Impacta.GAD.Application.Interfaces;
using Impacta.GAD.Repository.Helpers;
using Impacta.GAD.WebAPI.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Impacta.GAD.WebAPI.Controllers {

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase 
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IAccountService _accountService;

        public UsuarioController(IUsuarioService usuarioService,
                                      IWebHostEnvironment hostEnvironment,
                                      IAccountService accountService) {
            _hostEnvironment = hostEnvironment;
            _accountService = accountService;
            _usuarioService = usuarioService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] PageParams pageParams) {
            try {
                var usuarios = await _usuarioService.GetAllUsuariosAsync(pageParams, true);
                if (usuarios == null) return NoContent();

                Response.AddPagination(usuarios.CurrentPage,
                                       usuarios.PageSize,
                                       usuarios.TotalCount,
                                       usuarios.TotalPages);

                return Ok(usuarios);
            } catch (Exception ex) {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar usuarios. Erro: {ex.Message}");
            }
        }

        [HttpGet()]
        public async Task<IActionResult> GetUsuarios() {
            try {
                var usuario = await _usuarioService.GetUsuarioByUserIdAsync(User.GetUserId(), true);
                if (usuario == null) return NoContent();

                return Ok(usuario);
            } catch (Exception ex) {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar usuarios. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsuarioAddDTO model) {
            try {
                var usuario = await _usuarioService.GetUsuarioByUserIdAsync(User.GetUserId(), false);
                if (usuario == null)
                    usuario = await _usuarioService.AddUsuarios(User.GetUserId(), model);

                return Ok(usuario);
            } catch (Exception ex) {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar eventos. Erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(UsuarioUpdateDTO model) {
            try {
                var usuario = await _usuarioService.UpdateUsuario(User.GetUserId(), model);
                if (usuario == null) return NoContent();

                return Ok(usuario);
            } catch (Exception ex) {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar eventos. Erro: {ex.Message}");
            }
        }
    }
}
