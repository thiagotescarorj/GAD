using Impacta.GAD.Domain.Identity;
using Impacta.GAD.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Impacta.GAD.Repository.DataContext
{
    public class GADContext : IdentityDbContext<User, Role, long, IdentityUserClaim<long>,
                                               UserRole, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        public GADContext(DbContextOptions<GADContext> options)
           : base(options)
        {
        }

        public DbSet<Chamado> Chamado { get; set; }
        public DbSet<BancoDados> BancoDados { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<DNS> DNS { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioChamado> UsuarioChamados { get; set; }
        public DbSet<Projeto> Projetos { get; set; }

        //public DbSet<LogCrud> LogCrud { get; set; }
        //public DbSet<ProcedimentosComuns> ProcedimentosComuns { get; set; }
        //public DbSet<Backlog> Backlog { get; set; }
        //public DbSet<ToDo> ToDo { get; set; }
        //public DbSet<Glossario> Glossario { get; set; }
        //public DbSet<Solicitacao> Solicitacao { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(x => new { x.UserId, x.RoleId });

                userRole.HasOne(x => x.Role).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId).IsRequired();
                userRole.HasOne(x => x.User).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId).IsRequired();

            });
        }

    }
}
