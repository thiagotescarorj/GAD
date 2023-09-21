using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Domain.Models {
    public class UsuarioChamado 
    {
        public long Id { get; set; }
        public Usuario Usuario { get; set; }
        public long ChamadoId { get; set; } 
        public Chamado Chamado { get; set;}
    }
}
