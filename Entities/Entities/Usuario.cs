using Microsoft.AspNetCore.Identity;

namespace Entities.Entities
{
    public class Usuario : IdentityUser
    {
        public int NumeroConta { get; set; }
    }
}
