using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GestaoContaBancaria.Token
{
    public class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }
    }
}
