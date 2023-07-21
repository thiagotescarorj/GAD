using Impacta.GAD.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Application.Interfaces
{
    public interface IDNSService
    {
        Task<DNSDTO> AdicionarDNS(DNSDTO dns);
        Task<DNSDTO> AtualizarDNS(long dnsId, DNSDTO model);
        Task<bool> ExcluirDNS(long dnsId);
        Task<List<DNSDTO>> GetTodosDNS();
        Task<DNSDTO> GetDNSById(long dnsId);
        Task<List<DNSDTO>> GetTodosDNSByCliente(long dnsId);
        Task<List<DNSDTO>> GetTodosDNSByNome(string nome);
    }
}
