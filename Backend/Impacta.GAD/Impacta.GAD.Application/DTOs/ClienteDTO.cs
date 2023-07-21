using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Impacta.GAD.Application.DTOs
{
    public class ClienteDTO
    {
        public long Id { get; set; }

        [MaxLength(255)]
        [Required(ErrorMessage = "o campo Nome é obrígatório")]
        public string? Nome { get; set; }

        [Display(Name = "Ativo")]
        public string? IsAtivo { get; set; }

        [Display(Name = "Data Hora Cadastro")]
        public DateTime? DataHoraCadastro { get; set; }
    }
}
