using Impacta.GAD.Domain.Identity;
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
    public class UserRepository : GADRepository, IUserRepository
    {
        private readonly GADContext _context;

        public UserRepository(GADContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(long userId)
        {
            IQueryable<User> query = _context.Users.Where(x => x.Id == userId).AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetTodosUsers()
        {
            IQueryable<User> query = _context.Users.AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<List<User>> GetTodosAtivosUsers()
        {
            IQueryable<User> query = _context.Users.Where(x => x.IsAtivo == true).AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            IQueryable<User> query = _context.Users.Where(x => x.Email.ToLower() == email.ToLower()).AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }

    }
}
