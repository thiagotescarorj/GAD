namespace Impacta.GAD.Domain.Models
{
    public class BancoDados
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public bool IsAtivo { get; set; }

        public DateTime DataHoraCadastro { get; set; }


        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }


    }
}

