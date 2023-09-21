using Impacta.GAD.Domain.Models;
using Impacta.GAD.Repository.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Repository.Interfaces
{
    public interface IUsuarioRepository : IGADRepository
    {
        #region Usuario
        Task<PageList<Usuario>> GetTodosUsuariosAsync(PageParams pageParams, bool includeChamados = false);
        Task<Usuario> GetUsuarioByIdAsync(long UsuarioId);

        Task<Usuario> GetUsuarioByUserIdAsync(long userId, bool includeChamados);

        #endregion

    }
}
