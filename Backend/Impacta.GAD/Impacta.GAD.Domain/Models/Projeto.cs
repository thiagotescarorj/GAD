using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Domain.Models {
    public class Projeto {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public long? ChamadoId { get; set; }
        public Chamado Chamado { get; set; }
        public long? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
