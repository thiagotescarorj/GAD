using AutoMapper;
using Impacta.GAD.Application.DTOs;
using Impacta.GAD.Application.Interfaces;
using Impacta.GAD.Domain.Models;
using Impacta.GAD.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Application.Services
{
    public class ProjetoService: IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IMapper _mapper;

        public ProjetoService(IProjetoRepository projetoRepository,
                           IMapper mapper) {
            _projetoRepository = projetoRepository;
            _mapper = mapper;
        }

        public async Task AddProjeto(long Id, ProjetoDTO model, bool isChamado) {
            try {
                var projeto = _mapper.Map<Projeto>(model);
                if (isChamado) {
                    projeto.ChamadoId = Id;
                    projeto.UsuarioId = null;
                } else {
                    projeto.ChamadoId = null;
                    projeto.UsuarioId = Id;
                }

                _projetoRepository.Adicionar<Projeto>(projeto);

                await _projetoRepository.SalvarAlteracoesAsync();
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProjetoDTO[]> SaveByChamado(long chamadoId, ProjetoDTO[] models) {
            try {
                var projetos = await _projetoRepository.GetAllByChamadoIdAsync(chamadoId);
                if (projetos == null) return null;

                foreach (var model in models) {
                    if (model.Id == 0) {
                        await AddProjeto(chamadoId, model, true);
                    } else {
                        var projeto = projetos.FirstOrDefault(x => x.Id == model.Id);
                        model.ChamadoId = chamadoId;

                        _mapper.Map(model, projeto);

                        _projetoRepository.Atualizar<Projeto>(projeto);

                        await _projetoRepository.SalvarAlteracoesAsync();
                    }
                }

                var projetoRetorno = await _projetoRepository.GetAllByChamadoIdAsync(chamadoId);

                return _mapper.Map<ProjetoDTO[]>(projetoRetorno);
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProjetoDTO[]> SaveByUsuario(long usuarioId, ProjetoDTO[] models) {
            try {
                var projetos = await _projetoRepository.GetAllByUsuarioIdAsync(usuarioId);
                if (projetos == null) return null;

                foreach (var model in models) {
                    if (model.Id == 0) {
                        await AddProjeto(usuarioId, model, false);
                    } else {
                        var projeto = projetos.FirstOrDefault(x => x.Id == model.Id);
                        model.UsuarioId = usuarioId;

                        _mapper.Map(model, projeto);

                        _projetoRepository.Atualizar<Projeto>(projeto);

                        await _projetoRepository.SalvarAlteracoesAsync();
                    }
                }

                var ProjetoRetorno = await _projetoRepository.GetAllByUsuarioIdAsync(usuarioId);

                return _mapper.Map<ProjetoDTO[]>(ProjetoRetorno);
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteByChamado(long chamadoId, long projetoId) {
            try {
                var projeto = await _projetoRepository.GetProjetoChamadoByIdsAsync(chamadoId, projetoId);
                if (projeto == null) throw new Exception("Projeto não encontrado.");

                _projetoRepository.Excluir<Projeto>(projeto);
                return await _projetoRepository.SalvarAlteracoesAsync();
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteByUsuario(long usuarioId, long projetoId) {
            try {
                var projeto = await _projetoRepository.GetProjetoUsuarioByIdsAsync(usuarioId, projetoId);
                if (projeto == null) throw new Exception("Projeto não encontrado.");

                _projetoRepository.Excluir<Projeto>(projeto);
                return await _projetoRepository.SalvarAlteracoesAsync();
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProjetoDTO[]> GetAllByChamadoIdAsync(long chamadoId) {
            try {
                var projetos = await _projetoRepository.GetAllByChamadoIdAsync(chamadoId);
                if (projetos == null) return null;

                var resultado = _mapper.Map<ProjetoDTO[]>(projetos);

                return resultado;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProjetoDTO[]> GetAllByUsuarioIdAsync(long usuarioId) {
            try {
                var projetos = await _projetoRepository.GetAllByUsuarioIdAsync(usuarioId);
                if (projetos == null) return null;

                var resultado = _mapper.Map<ProjetoDTO[]>(projetos);

                return resultado;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProjetoDTO> GetProjetoChamadoByIdsAsync(long chamadoId, long projetoId) {
            try {
                var projeto = await _projetoRepository.GetProjetoChamadoByIdsAsync(chamadoId, projetoId);
                if (projeto == null) return null;

                var resultado = _mapper.Map<ProjetoDTO>(projeto);

                return resultado;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProjetoDTO> GetProjetoUsuarioByIdsAsync(long usuarioId, long projetoId) {
            try {
                var projeto = await _projetoRepository.GetProjetoUsuarioByIdsAsync(usuarioId, projetoId);
                if (projeto == null) return null;

                var resultado = _mapper.Map<ProjetoDTO>(projeto);

                return resultado;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

    }

}
