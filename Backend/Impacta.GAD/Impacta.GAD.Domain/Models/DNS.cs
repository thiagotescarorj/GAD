using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Domain.Models
{
    public class DNS
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public bool IsAtivo { get; set; }
        public bool IsAtividade { get; set; }

        public long UsuarioCadastoId { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }



    }
}
