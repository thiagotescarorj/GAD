﻿using Impacta.GAD.Domain.Models;
using Impacta.GAD.Repository.DataContext;
using Impacta.GAD.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Repository.Repositories
{
    public class ChamadoRepository : IChamadoRepository
    {
        private readonly GADContext _context;


        public ChamadoRepository(GADContext context)
        {
            _context = context;

        }

        public void Adicionar<Chamado>(Chamado chamado)
        {
            _context.Add(chamado);
        }

        public void Atualizar<Chamado>(Chamado chamado)
        {
            _context.Update(chamado);
        }

        public void Excluir<Chamado>(Chamado chamado)
        {
            _context.Remove(chamado);
        }

        public void ExcluirVarios<Chamado>(List<Chamado> chamadoList)
        {
            _context.RemoveRange(chamadoList);
        }

        public async Task<bool> SalvarAlteracoesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Chamado> GetChamadoByIdAsync(long userId, long chamadoId, bool includeUsuarios = false)
        {
            IQueryable<Chamado> query = _context.Chamado
                .Include(e => e.Projetos);

            if (includeUsuarios) {
                query = query
                    .Include(e => e.UsuarioChamados)
                    .ThenInclude(pe => pe.Usuario);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                         .Where(e => e.Id == chamadoId && e.UserId == userId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Chamado> GetChamadoByUser(long chamadoId, long userId) {
            IQueryable<Chamado> query = _context.Chamado.Where(x => x.Id == chamadoId && x.UserId == userId);

            return await query.AsNoTracking().FirstOrDefaultAsync();


        }

        public List<Chamado> GetTodosChamados()
        {
            IQueryable<Chamado> query = _context.Chamado.AsQueryable();
            //.Include(x => x.BancoDadosId)
            //.Include(x => x.DNSId)
            //.Include(x => x.ClienteId).AsQueryable();
            if (query == null)
            {
                return null;
            }
            return query.AsNoTracking().ToList();
        }

        public List<Chamado> GetTodosChamadosFromUser(long userId)
        {
            IQueryable<Chamado> query = _context.Chamado.Where(x => x.Id == userId).AsQueryable();
            //.Include(x => x.BancoDadosId)
            //.Include(x => x.DNSId)
            //.Include(x => x.ClienteId).AsQueryable();
            if (query == null)
            {
                return null;
            }
            return query.AsNoTracking().ToList();
        }

        public async Task<List<Chamado>> GetTodosAtivosChamados()
        {
            IQueryable<Chamado> query = _context.Chamado;

            return await query.AsNoTracking().Where(x => x.IsAtivo == true).ToListAsync();
        }

        public async Task<List<Chamado>> GetTodosChamadosByBancoDados(long bancoDadosId)
        {
            IQueryable<Chamado> query = _context.Chamado;

            return await query.AsNoTracking().Where(x => x.IsAtivo == true && x.BancoDadosId == bancoDadosId).ToListAsync();
        }

        public async Task<List<Chamado>> GetTodosChamadosByCliente(long clienteId)
        {
            IQueryable<Chamado> query = _context.Chamado;

            return await query.AsNoTracking().Where(x => x.IsAtivo == true && x.ClienteId == clienteId).ToListAsync();
        }

        public async Task<List<Chamado>> GetTodosChamadosByDns(long dnsId)
        {
            IQueryable<Chamado> query = _context.Chamado;

            return await query.AsNoTracking().Where(x => x.IsAtivo == true && x.DNSId == dnsId).ToListAsync();
        }

        public async Task<List<Chamado>> GetTodosChamadosByNumero(string numero)
        {
            IQueryable<Chamado> query = _context.Chamado;

            return await query.AsNoTracking().Where(x => x.IsAtivo == true && x.Numero.Contains(numero)).ToListAsync();
        }


    }
}
