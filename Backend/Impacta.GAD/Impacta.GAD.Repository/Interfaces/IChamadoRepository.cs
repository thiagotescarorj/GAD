using Impacta.GAD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Repository.Interfaces
{
    public interface IChamadoRepository : IGADRepository
    {

        #region Chamado
        List<Chamado> GetTodosChamados();
        List<Chamado> GetTodosChamadosFromUser(long userId);
        Task<Chamado> GetChamadoById(long chamadoId);
        Task<Chamado> GetChamadoByUser(long chamadoId, long userId);
        Task<List<Chamado>> GetTodosChamadosByNumero(string numero);
        Task<List<Chamado>> GetTodosChamadosByCliente(long clienteId);
        Task<List<Chamado>> GetTodosChamadosByDns(long dnsId);
        Task<List<Chamado>> GetTodosChamadosByBancoDados(long bancoDadosId);
        #endregion



    }
}
