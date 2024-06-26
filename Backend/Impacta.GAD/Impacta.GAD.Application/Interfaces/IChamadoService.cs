﻿using Impacta.GAD.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Application.Interfaces
{
    public interface IChamadoService
    {
        Task<ChamadoDTO> AdicionarChamado(ChamadoDTO chamado, long usuarioLogadoId);
        Task<ChamadoDTO> AtualizarChamado(long usuarioLogadoId, long chamadoId, ChamadoDTO model);
        Task<bool> ExcluirChamado(long usuarioLogadoId,long chamadoId);
        Task<List<ChamadoDTO>> GetTodosChamados();
        Task<ChamadoDTO> GetChamadoByIdAsync(long userId, long chamadoId, bool includeUsuarios = false);
        Task<List<ChamadoDTO>> GetTodosChamadosFromUser(long userId);


        //Task<ChamadoDTO> GetChamadoById(long chamadoId);
        //Task<ChamadoDTO> GetChamadoFromUser(long chamadoId,long userId);
        //Task<List<ChamadoDTO>> GetTodosChamadosByNumero(string numero);
        //Task<List<ChamadoDTO>> GetTodosChamadosByCliente(long clienteId);
        //Task<List<ChamadoDTO>> GetTodosChamadosByDns(long dnsId);
        //Task<List<ChamadoDTO>> GetTodosChamadosByBancoDados(long bancoDadosId);
    }
}
