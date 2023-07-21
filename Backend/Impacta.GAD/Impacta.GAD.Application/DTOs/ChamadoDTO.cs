using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Impacta.GAD.Application.DTOs
{
    public class ChamadoDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo Número é obrigatório")]
        [Display(Name = "Número")]
        public string? Numero { get; set; }

        [Display(Name = "Ativo")]
        public string? IsAtivo { get; set; }

        [Display(Name = "Data Hora Cadastro")]
        public DateTime? DataHoraCadastro { get; set; }

        [Required(ErrorMessage = "O campo Data do Recebimento é obrigatório")]
        [Display(Name = "Data do Recebimento")]
        public DateTime? DataRecebimento { get; set; }

        [Display(Name = "Data da Publicação")]
        public DateTime? DataPublicacao { get; set; }

        [Display(Name = "Data do Envio para Homologação")]
        public DateTime? DataEnvioHomologacao { get; set; }

        [Display(Name = "Observação")]
        public string? Observacao { get; set; }

        [Display(Name = "Script SQL")]
        public string? ScriptText { get; set; }

        [Required(ErrorMessage = "O campo Cliente é obrigatório")]
        public long ClienteId { get; set; }

        [Required(ErrorMessage = "O campo Banco de Dados é obrigatório")]
        public long BancoDadosId { get; set; }

        [Required(ErrorMessage = "O campo DNS é obrigatório")]
        public long DNSId { get; set; }
        public long UserId { get; set; }
    }
}
