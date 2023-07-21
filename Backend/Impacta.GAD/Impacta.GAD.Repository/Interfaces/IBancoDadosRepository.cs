using Impacta.GAD.Domain.Models;

namespace Impacta.GAD.Repository.Interfaces
{
    public interface IBancoDadosRepository : IGADRepository
    {
        #region BancoDados
        Task<List<BancoDados>> GetTodosBancoDados();
        Task<BancoDados> GetBancoDadosById(long bancoDadosId);
        Task<List<BancoDados>> GetTodosBancoDadosByCliente(long clienteId);
        Task<List<BancoDados>> GetTodosBancoDadosByNome(string nome);
        #endregion

    }
}
