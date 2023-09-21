using Impacta.GAD.Domain.Models;
using Impacta.GAD.Repository.DataContext;
using Impacta.GAD.Repository.Helpers;
using Impacta.GAD.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Repository.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly GADContext _context;

        public ClienteRepository(GADContext context)
        {
            _context = context;
        }

        public void Adicionar<Cliente>(Cliente cliente)
        {
            _context.Add(cliente);
        }

        public void Atualizar<Cliente>(Cliente cliente)
        {
            _context.Update(cliente);
        }

        public void Excluir<Cliente>(Cliente cliente)
        {
            _context.Remove(cliente);
        }

        public void ExcluirVarios<Cliente>(List<Cliente> clienteList)
        {
            _context.RemoveRange(clienteList);
        }

        public async Task<Cliente> GetClienteById(long clienteId)
        {
            IQueryable<Cliente> query = _context.Cliente.Where(x => x.Id == clienteId).AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }

        public async Task<PageList<Cliente>> GetTodosClientes(PageParams pageParams)
        {
            IQueryable<Cliente> query = _context.Cliente
                                             .AsNoTracking()
                                             .Where(x => x.Nome.ToLower().Contains(pageParams.Term.ToLower())
                                                      || x.DataHoraCadastro.ToString().Contains(pageParams.Term));
            return await PageList<Cliente>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public async Task<List<Cliente>> GetTodosAtivosClientes()
        {
            IQueryable<Cliente> query = _context.Cliente.Where(x => x.IsAtivo == true).AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<List<Cliente>> GetTodosClientesByNome(string nome)
        {
            IQueryable<Cliente> query = _context.Cliente.Where(x => x.Nome.Contains(nome)).AsNoTracking();
            return await query.ToListAsync();
        }

        public Task<bool> SalvarAlteracoesAsync()
        {
            throw new NotImplementedException();
        }
    }

}
