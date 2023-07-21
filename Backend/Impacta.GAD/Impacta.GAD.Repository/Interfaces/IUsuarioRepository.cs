using Impacta.GAD.Domain.Models;
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
        Task<List<Usuario>> GetTodosUsuarios();
        Task<Usuario> GetUsuarioById(long UsuarioId);

        #endregion

    }
}
