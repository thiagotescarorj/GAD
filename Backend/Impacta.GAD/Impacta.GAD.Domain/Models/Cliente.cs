using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Domain.Models
{
    public class Cliente
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public bool IsAtivo { get; set; }

        public long UsuarioCadastoId { get; set; }
        public DateTime DataHoraCadastro { get; set; }

        //public ICollection<Chamado>? Chamados { get; set;}
        //public ICollection<DNS>? DNSs { get; set;}
        //public ICollection<BancoDados>? BancosDados { get; set;}



    }
}
