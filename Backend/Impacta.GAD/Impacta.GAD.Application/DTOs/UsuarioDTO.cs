using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Application.DTOs
{
    public class UsuarioDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public UserUpdateDTO User { get; set; }
        public IEnumerable<ProjetoDTO> Projetos { get; set; }
        public IEnumerable<ChamadoDTO> Chamados { get; set; }
    }
}
