using Impacta.GAD.Domain.Enumeradores;
using Microsoft.AspNetCore.Identity;

namespace Impacta.GAD.Domain.Identity
{
    public class User : IdentityUser<long>
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string NomeCompleto { get; set; }
        public bool IsAtivo { get; set; }
        public EnumPefil PerfilUsuario { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
        

    }
}
