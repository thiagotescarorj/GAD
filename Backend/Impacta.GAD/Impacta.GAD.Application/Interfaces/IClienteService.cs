using Impacta.GAD.Application.DTOs;
using Impacta.GAD.Repository.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Application.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDTO> AdicionarCliente(ClienteDTO cliente);
        Task<ClienteDTO> AtualizarCliente(long clienteId, ClienteDTO model);
        Task<bool> ExcluirCliente(long clienteId);
        Task<List<ClienteDTO>> GetTodosClientes(PageParams pageParams);
        Task<ClienteDTO> GetClienteById(long clienteId);
        Task<List<ClienteDTO>> GetTodosClientesByNome(string nome);
    }
}
