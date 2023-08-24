using Impacta.GAD.Domain.Models;
using Impacta.GAD.Repository.Helpers;
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
        Task<PageList<Cliente>> GetTodosClientes(PageParams pageParams);
        Task<Cliente> GetClienteById(long clienteId);
        #endregion


    }
}
