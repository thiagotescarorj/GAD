using Impacta.GAD.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Application.Interfaces
{
    public interface IProjetoService
    {
        Task<ProjetoDTO[]> SaveByChamado(long chamadoId, ProjetoDTO[] models);
        Task<bool> DeleteByChamado(long chamadoId, long redeSocialId);

        Task<ProjetoDTO[]> SaveByUsuario(long usuarioId, ProjetoDTO[] models);
        Task<bool> DeleteByUsuario(long usuarioId, long redeSocialId);

        Task<ProjetoDTO[]> GetAllByChamadoIdAsync(long chamadoId);
        Task<ProjetoDTO[]> GetAllByUsuarioIdAsync(long usuarioId);

        Task<ProjetoDTO> GetProjetoChamadoByIdsAsync(long chamadoId, long ProjetoId);
        Task<ProjetoDTO> GetProjetoUsuarioByIdsAsync(long UsuarioId, long ProjetoId);
    }
}
