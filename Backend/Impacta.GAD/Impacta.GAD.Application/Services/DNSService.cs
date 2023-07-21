using AutoMapper;
using Impacta.GAD.Application.DTOs;
using Impacta.GAD.Application.Interfaces;
using Impacta.GAD.Domain.Models;
using Impacta.GAD.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Application.Services
{
    public class DNSService : IDNSService
    {
        private readonly IGADRepository _GBTRepository;
        private readonly IDNSRepository _dnsRepository;
        private readonly IMapper _mapper;

        public DNSService(IGADRepository gBTRepository, IDNSRepository dnsRepository, IMapper mapper)
        {
            _GBTRepository = gBTRepository;
            _dnsRepository = dnsRepository;
            _mapper = mapper;
        }
        public async Task<DNSDTO> AdicionarDNS(DNSDTO model)
        {
            try
            {
                var dns = _mapper.Map<DNS>(model);

                _GBTRepository.Adicionar<DNS>(dns);

                if (await _GBTRepository.SalvarAlteracoesAsync())
                {
                    var retorno = await _dnsRepository.GetDNSById(dns.Id);
                    return _mapper.Map<DNSDTO>(retorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DNSDTO> AtualizarDNS(long dnsId, DNSDTO model)
        {
            try
            {
                var dns = await _dnsRepository.GetDNSById(dnsId);
                if (dns == null) return null;

                model.Id = dns.Id;

                var resultado = _mapper.Map(model, dns);

                _GBTRepository.Atualizar(resultado);

                if (await _GBTRepository.SalvarAlteracoesAsync())
                {
                    var retorno = await _dnsRepository.GetDNSById(dns.Id);

                    return _mapper.Map<DNSDTO>(retorno);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ExcluirDNS(long dnsId)
        {
            try
            {
                var dns = await _dnsRepository.GetDNSById(dnsId);
                if (dns == null)
                {
                    throw new Exception($"DNS de Id {dnsId} não foi localizado.");
                }
                _GBTRepository.Excluir<DNS>(dns);

                return await _GBTRepository.SalvarAlteracoesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<DNSDTO>> GetTodosDNS()
        {
            try
            {
                var dnsList = await _dnsRepository.GetTodosDNS();
                if (dnsList == null) return null;

                var retorno = _mapper.Map<List<DNSDTO>>(dnsList);
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DNSDTO> GetDNSById(long dnsId)
        {
            try
            {
                var dns = await _dnsRepository.GetDNSById(dnsId);
                if (dns == null) return null;
                var retorno = _mapper.Map<DNSDTO>(dns);
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<DNSDTO>> GetTodosDNSByCliente(long clienteId)
        {
            try
            {
                var dnsList = await _dnsRepository.GetTodosDNSByCliente(clienteId);
                if (dnsList == null) return null;
                var retorno = _mapper.Map<List<DNSDTO>>(dnsList);
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<DNSDTO>> GetTodosDNSByNome(string nome)
        {
            try
            {
                var dnsList = await _dnsRepository.GetTodosDNSByNome(nome);
                if (dnsList == null) return null;
                var retorno = _mapper.Map<List<DNSDTO>>(dnsList);
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

