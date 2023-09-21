using Impacta.GAD.Domain.Enumeradores;
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
    public class UsuarioRepository : GADRepository, IUsuarioRepository
    {
        private readonly GADContext _context;

        public UsuarioRepository(GADContext context):base(context)
        {
            _context = context;
        }

        public async Task<PageList<Usuario>> GetTodosUsuariosAsync(PageParams pageParams, bool includeChamados = false) {
            //IQueryable<Usuario> query = _context.Usuario.AsNoTracking();
            //return await query.ToListAsync();

            IQueryable<Usuario> query = _context.Usuario
               .Include(p => p.User)
               .Include(p => p.Projeto);

            if (includeChamados) {
                query = query
                    .Include(p => p.UsuarioChamados)
                    .ThenInclude(pe => pe.Chamado);
            }

            query = query.AsNoTracking()
                         .Where(p => (p.User.Nome.ToLower().Contains(pageParams.Term.ToLower()) ||
                                      p.User.Sobrenome.ToLower().Contains(pageParams.Term.ToLower())) &&
                                      p.User.PerfilUsuario == EnumPefil.Desenvolvedor)
                         .OrderBy(p => p.Id);

            return await PageList<Usuario>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);
        }
            
        public async Task<Usuario> GetUsuarioByUserIdAsync(long userId, bool includeChamados) {
            IQueryable<Usuario> query = _context.Usuario
                .Include(p => p.User)
                .Include(p => p.Projeto);

            if (includeChamados) {
                query = query
                    .Include(p => p.UsuarioChamados)
                    .ThenInclude(pe => pe.Chamado);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id)
                         .Where(p => p.UserId == userId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(long usuarioId)
        {
            IQueryable<Usuario> query = _context.Usuario
                                                 .Where(x => x.Id == usuarioId).AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }

    }
}
