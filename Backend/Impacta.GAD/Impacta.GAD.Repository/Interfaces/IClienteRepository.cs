using Impacta.GAD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Repository.Interfaces
{
    public interface IClienteRepository : IGADRepository
    {
        #region Cliente
        Task<List<Cliente>> GetTodosClientes();
        Task<Cliente> GetClienteById(long clienteId);
        Task<List<Cliente>> GetTodosClientesByNome(string nome);
        #endregion


    }
}
