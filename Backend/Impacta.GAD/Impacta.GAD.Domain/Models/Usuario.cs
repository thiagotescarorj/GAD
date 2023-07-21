using Impacta.GAD.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Domain.Models
{
    public class Usuario
    {
        public long Id { get; set; }
        public bool IsAtivo { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
