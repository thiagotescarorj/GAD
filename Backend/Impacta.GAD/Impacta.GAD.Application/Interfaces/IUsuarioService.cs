using Impacta.GAD.Application.DTOs;
using Impacta.GAD.Repository.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Application.Interfaces {
    public interface IUsuarioService 
    {
        Task<UsuarioDTO> AddUsuarios(long userId, UsuarioAddDTO model);
        Task<UsuarioDTO> UpdateUsuario(long userId, UsuarioUpdateDTO model);

        Task<PageList<UsuarioDTO>> GetAllUsuariosAsync(PageParams pageParams, bool includeChamados = false);
        Task<UsuarioDTO> GetUsuarioByUserIdAsync(long userId, bool includeChamados = false);
    }
}
