using Impacta.GAD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Repository.Interfaces
{
    public interface IDNSRepository : IGADRepository
    {
        #region DNS
        Task<List<DNS>> GetTodosDNS();
        Task<DNS> GetDNSById(long dnsId);
        Task<List<DNS>> GetTodosDNSByCliente(long clienteId);
        Task<List<DNS>> GetTodosDNSByNome(string nome);
        #endregion

    }
}
