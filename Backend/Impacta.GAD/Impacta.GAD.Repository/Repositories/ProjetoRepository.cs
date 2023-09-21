using Impacta.GAD.Domain.Models;
using Impacta.GAD.Repository.DataContext;
using Impacta.GAD.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Repository.Repositories {
    public class ProjetoRepository : GADRepository, IProjetoRepository {
        private readonly GADContext _context;

        public ProjetoRepository(GADContext context) : base(context) {
            _context = context;
        }
        public async Task<Projeto> GetProjetoChamadoByIdsAsync(long chamadoId, long id) {
            IQueryable<Projeto> query = _context.Projetos;

            query = query.AsNoTracking()
                         .Where(x => x.ChamadoId == chamadoId &&
                                      x.Id == id);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Projeto> GetProjetoUsuarioByIdsAsync(long usuarioId, long id) {
            IQueryable<Projeto> query = _context.Projetos;

            query = query.AsNoTracking()
                         .Where(rs => rs.UsuarioId == usuarioId &&
                                      rs.Id == id);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Projeto[]> GetAllByChamadoIdAsync(long chamadoId) {
            IQueryable<Projeto> query = _context.Projetos;

            query = query.AsNoTracking()
                         .Where(rs => rs.ChamadoId == chamadoId);

            return await query.ToArrayAsync();
        }
        public async Task<Projeto[]> GetAllByUsuarioIdAsync(long usuarioId) {
            IQueryable<Projeto> query = _context.Projetos;

            query = query.AsNoTracking()
                         .Where(rs => rs.UsuarioId == usuarioId);

            return await query.ToArrayAsync();
        }
    }

}
