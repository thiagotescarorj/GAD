using AutoMapper;
using Impacta.GAD.Application.DTOs;
using Impacta.GAD.Application.Interfaces;
using Impacta.GAD.Domain.Models;
using Impacta.GAD.Repository.Interfaces;

namespace Impacta.GAD.Application.Services
{
    public class BancoDadosService : IBancoDadosService
    {
        private readonly IGADRepository _GBTRepository;
        private readonly IBancoDadosRepository _bancoDadosRepository;
        private readonly IMapper _mapper;

        public BancoDadosService(IGADRepository gBTRepository, IBancoDadosRepository bancoDadosRepository, IMapper mapper)
        {
            _GBTRepository = gBTRepository;
            _bancoDadosRepository = bancoDadosRepository;
            _mapper = mapper;
        }

        public async Task<BancoDadosDTO> AdicionarBancoDados(BancoDadosDTO model)
        {
            try
            {
                var bancoDados = _mapper.Map<BancoDados>(model);

                bancoDados.DataHoraCadastro = DateTime.Now;
                bancoDados.IsAtivo = true;

                _GBTRepository.Adicionar<BancoDados>(bancoDados);

                if (await _GBTRepository.SalvarAlteracoesAsync())
                {
                    var retorno = await _bancoDadosRepository.GetBancoDadosById(bancoDados.Id);
                    return _mapper.Map<BancoDadosDTO>(bancoDados);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BancoDadosDTO> AtualizarBancoDados(long bancoDadosId, BancoDadosDTO model)
        {
            try
            {
                var bancoDado = await _bancoDadosRepository.GetBancoDadosById(bancoDadosId);

                if (bancoDado == null) return null;

                model.Id = bancoDado.Id;

                var resultado = _mapper.Map(model, bancoDado);

                _GBTRepository.Atualizar(resultado);

                if (await _GBTRepository.SalvarAlteracoesAsync())
                {
                    var retorno = await _bancoDadosRepository.GetBancoDadosById(bancoDado.Id);
                    return _mapper.Map<BancoDadosDTO>(retorno);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ExcluirBancoDados(long bancoDadosId)
        {
            try
            {
                var bancoDados = await _bancoDadosRepository.GetBancoDadosById(bancoDadosId);
                if (bancoDados == null)
                {
                    throw new Exception($"Banco de Dados de Id {bancoDadosId} não foi localizado.");
                }
                _GBTRepository.Excluir<BancoDados>(bancoDados);

                return await _GBTRepository.SalvarAlteracoesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<BancoDadosDTO>> GetTodosBancoDados()
        {
            try
            {
                var bancosDados = await _bancoDadosRepository.GetTodosBancoDados();

                if (bancosDados == null) return null;

                var resultado = _mapper.Map<List<BancoDadosDTO>>(bancosDados);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BancoDadosDTO> GetBancoDadosById(long bancoDadosId)
        {
            try
            {
                var bancosDados = await _bancoDadosRepository.GetBancoDadosById(bancoDadosId);

                if (bancosDados == null) return null;

                var resultado = _mapper.Map<BancoDadosDTO>(bancosDados);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<BancoDadosDTO>> GetTodosBancoDadosByCliente(long clienteId)
        {
            try
            {
                var bancosDados = await _bancoDadosRepository.GetTodosBancoDadosByCliente(clienteId);

                if (bancosDados == null) return null;

                var resultado = _mapper.Map<List<BancoDadosDTO>>(bancosDados);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<BancoDadosDTO>> GetTodosBancoDadosByNome(string nome)
        {
            try
            {
                var bancosDados = await _bancoDadosRepository.GetTodosBancoDadosByNome(nome);

                if (bancosDados == null) return null;

                var resultado = _mapper.Map<List<BancoDadosDTO>>(bancosDados);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
