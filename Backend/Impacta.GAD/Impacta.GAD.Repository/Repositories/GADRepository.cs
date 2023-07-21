using Impacta.GAD.Repository.DataContext;
using Impacta.GAD.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Repository.Repositories
{
    public class GADRepository : IGADRepository
    {
        private readonly GADContext _context;
        public GADRepository(GADContext context)
        {
            _context = context;
        }

        public void Adicionar<T>(T entity)
        {
            _context.Add(entity);
        }

        public void Atualizar<T>(T entity)
        {
            _context.Update(entity);
        }

        public void Excluir<T>(T entity)
        {
            _context.Remove(entity);
        }

        public void ExcluirVarios<T>(List<T> entityList)
        {
            _context.RemoveRange(entityList);
        }

        public async Task<bool> SalvarAlteracoesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}
