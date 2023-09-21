using Impacta.GAD.Application.DTOs;
using Impacta.GAD.Repository.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Application.Interfaces
{
    public interface IBancoDadosService
    {
        Task<BancoDadosDTO> AdicionarBancoDados(BancoDadosDTO chamado);
        Task<BancoDadosDTO> AtualizarBancoDados(long chamadoId, BancoDadosDTO model);
        Task<bool> ExcluirBancoDados(long chamadoId);
        Task<List<BancoDadosDTO>> GetTodosBancoDados();
        Task<BancoDadosDTO> GetBancoDadosById(long bancoDadosId);
        //Task<List<BancoDadosDTO>> GetTodosBancoDadosByCliente(long clienteId);
        //Task<List<BancoDadosDTO>> GetTodosBancoDadosByNome(string nome);

        //Task<ChamadoDTO> AddChamados(long userId, ChamadoDTO model);
        //Task<ChamadoDTO> UpdateChamado(long userId, long eventoId, ChamadoDTO model);
        //Task<bool> DeleteChamado(long userId, long eventoId);

        //Task<PageList<ChamadoDTO>> GetAllChamadosAsync(long userId, PageParams pageParams, bool includeUsuarios = false);
        //Task<ChamadoDTO> GetChamadoByIdAsync(long userId, long eventoId, bool includeUsuarios = false);
    }
}
