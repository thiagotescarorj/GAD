using AutoMapper;
using Impacta.GAD.Application.DTOs;
using Impacta.GAD.Application.Interfaces;
using Impacta.GAD.Domain.Models;
using Impacta.GAD.Repository.Helpers;
using Impacta.GAD.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Application.Services
{
    public class UsuarioService: IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository usuarioRepository,
                                  IMapper mapper) {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> AddUsuarios(long userId, UsuarioAddDTO model) {
            try {
                var usuario = _mapper.Map<Usuario>(model);
                usuario.UserId = userId;

                _usuarioRepository.Adicionar<Usuario>(usuario);

                if (await _usuarioRepository.SalvarAlteracoesAsync()) {
                    var UsuarioRetorno = await _usuarioRepository.GetUsuarioByUserIdAsync(userId, false);

                    return _mapper.Map<UsuarioDTO>(UsuarioRetorno);
                }
                return null;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioDTO> UpdateUsuario(long userId, UsuarioUpdateDTO model) {
            try {
                var usuario = await _usuarioRepository.GetUsuarioByUserIdAsync(userId, false);
                if (usuario == null) return null;

                model.Id = usuario.Id;
                model.UserId = userId;

                _mapper.Map(model, usuario);

                _usuarioRepository.Atualizar<Usuario>(usuario);

                if (await _usuarioRepository.SalvarAlteracoesAsync()) {
                    var usuarioRetorno = await _usuarioRepository.GetUsuarioByUserIdAsync(userId, false);

                    return _mapper.Map<UsuarioDTO>(usuarioRetorno);
                }
                return null;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PageList<UsuarioDTO>> GetAllUsuariosAsync(PageParams pageParams, bool includeChamados = false) {
            try {
                var usuarios = await _usuarioRepository.GetTodosUsuariosAsync(pageParams, includeChamados);
                if (usuarios == null) return null;

                var resultado = _mapper.Map<PageList<UsuarioDTO>>(usuarios);

                resultado.CurrentPage = usuarios.CurrentPage;
                resultado.TotalPages = usuarios.TotalPages;
                resultado.PageSize = usuarios.PageSize;
                resultado.TotalCount = usuarios.TotalCount;

                return resultado;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioDTO> GetUsuarioByUserIdAsync(long userId, bool includeChamados = false) {
            try {
                var usuario = await _usuarioRepository.GetUsuarioByUserIdAsync(userId, includeChamados);
                if (usuario == null) return null;

                var resultado = _mapper.Map<UsuarioDTO>(usuario);

                return resultado;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }

}
