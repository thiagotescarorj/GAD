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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GADContext _context;

        public UsuarioRepository(GADContext context)
        {
            _context = context;
        }

        public void Adicionar<Usuario>(Usuario usuario)
        {
            _context.Add(usuario);
        }

        public void Atualizar<Usuario>(Usuario usuario)
        {
            _context.Update(usuario);
        }

        public void Excluir<Usuario>(Usuario usuario)
        {
            _context.Remove(usuario);
        }

        public void ExcluirVarios<Usuario>(List<Usuario> usuarioList)
        {
            _context.RemoveRange(usuarioList);
        }

        public async Task<Usuario> GetUsuarioById(long usuarioId)
        {
            IQueryable<Usuario> query = _context.Usuario.Where(x => x.Id == usuarioId).AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Usuario>> GetTodosUsuarios()
        {
            IQueryable<Usuario> query = _context.Usuario.AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<List<Usuario>> GetTodosAtivosUsuarios()
        {
            IQueryable<Usuario> query = _context.Usuario.Where(x => x.IsAtivo == true).AsNoTracking();
            return await query.ToListAsync();
        }

        public Task<bool> SalvarAlteracoesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
