using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Repository.Interfaces
{
    public interface IGADRepository
    {
        #region Geral
        void Adicionar<T>(T entity);
        void Atualizar<T>(T entity);
        void Excluir<T>(T entity);
        void ExcluirVarios<T>(List<T> entityList);

        Task<bool> SalvarAlteracoesAsync();
        #endregion


    }
}
