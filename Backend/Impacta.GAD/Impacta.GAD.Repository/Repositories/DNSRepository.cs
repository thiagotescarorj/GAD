using Impacta.GAD.Domain.Models;
using Impacta.GAD.Repository.DataContext;
using Impacta.GAD.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Repository.Repositories
{
    public class DNSRepository : IDNSRepository
    {
        private readonly GADContext _context;

        public DNSRepository(GADContext context)
        {
            _context = context;
        }

        public void Adicionar<DNS>(DNS dns)
        {
            _context.Add(dns);
        }

        public void Atualizar<DNS>(DNS dns)
        {
            _context.Update(dns);
        }

        public void Excluir<DNS>(DNS dns)
        {
            _context.Remove(dns);
        }

        public void ExcluirVarios<DNS>(List<DNS> dnsList)
        {
            _context.RemoveRange(dnsList);
        }

        public async Task<bool> SalvarAlteracoesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<DNS> GetDNSById(long dnsId)
        {
            IQueryable<DNS> query = _context.DNS.Where(x => x.Id == dnsId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<DNS>> GetTodosDNS()
        {
            IQueryable<DNS> query = _context.DNS;
            return await query.ToListAsync();
        }

        public async Task<List<DNS>> GetTodosDNSByCliente(long clienteId)
        {
            IQueryable<DNS> query = _context.DNS.Include(x => x.ClienteId).Where(x => x.ClienteId == clienteId);
            return await query.ToListAsync();
        }

        public async Task<List<DNS>> GetTodosDNSByNome(string nome)
        {
            IQueryable<DNS> query = _context.DNS.Include(x => x.ClienteId).Where(x => x.Nome.Contains(nome));
            return await query.ToListAsync();
        }


    }
}
