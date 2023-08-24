using AutoMapper;
using Impacta.GAD.Application.DTOs;
using Impacta.GAD.Application.Interfaces;
using Impacta.GAD.Domain.Models;
using Impacta.GAD.Repository.Helpers;
using Impacta.GAD.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IGADRepository _GBTRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IGADRepository gBTRepository, IClienteRepository clienteRepository, IMapper mapper)
        {
            _GBTRepository = gBTRepository;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteDTO> AdicionarCliente(ClienteDTO model)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(model);

                _GBTRepository.Adicionar<Cliente>(cliente);

                if (await _GBTRepository.SalvarAlteracoesAsync())
                {
                    var retorno = await _clienteRepository.GetClienteById(cliente.Id);

                    return _mapper.Map<ClienteDTO>(retorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteDTO> AtualizarCliente(long clienteId, ClienteDTO model)
        {
            try
            {
                var cliente = await _clienteRepository.GetClienteById(clienteId);
                if (cliente == null) return null;

                model.Id = cliente.Id;

                var resultado = _mapper.Map(model, cliente);

                _GBTRepository.Atualizar(resultado);

                if (await _GBTRepository.SalvarAlteracoesAsync())
                {
                    var retorno = await _clienteRepository.GetClienteById(cliente.Id);

                    return _mapper.Map<ClienteDTO>(retorno);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ExcluirCliente(long clienteId)
        {
            try
            {
                var cliente = await _clienteRepository.GetClienteById(clienteId);
                if (cliente == null)
                {
                    throw new Exception($"Cliente de Id {clienteId} não foi localizado.");
                }
                _GBTRepository.Excluir<Cliente>(cliente);

                return await _GBTRepository.SalvarAlteracoesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<ClienteDTO>> GetTodosClientes(PageParams pageParams)
        {
            try
            {
                var clientes = await _clienteRepository.GetTodosClientes(pageParams);

                if (clientes == null) return null;

                var retorno = _mapper.Map<PageList<ClienteDTO>>(clientes);

                retorno.CurrentPage = clientes.CurrentPage;
                retorno.TotalPages = clientes.TotalPages;
                retorno.PageSize = clientes.PageSize;
                retorno.TotalCount = clientes.TotalCount;

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteDTO> GetClienteById(long clienteId)
        {
            try
            {
                var cliente = await _clienteRepository.GetClienteById(clienteId);
                if (cliente == null) return null;

                var retorno = _mapper.Map<ClienteDTO>(cliente);

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<ClienteDTO>> GetTodosClientesByNome(string nome)
        {
            try
            {
                var clientes = await _clienteRepository.GetTodosClientesByNome(nome);
                if (clientes == null) return null;

                var retorno = _mapper.Map<List<ClienteDTO>>(clientes);

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
