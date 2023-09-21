using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Application.DTOs
{
    public class ProjetoDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public long? ChamadoId { get; set; }
        public ChamadoDTO Chamado { get; set; }
        public long? UsuarioId { get; set; }
        public UsuarioDTO Usuario { get; set; }
    }
}
