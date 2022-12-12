using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApi.Authorization
{
    public class AuthOptions
    {
        public const string ISSUER = "TodoApp";
        public const string AUDIENCE = "TodoAppClient";
        const string KEY = "todoapplication_secretkey!123";
        public const int LIFETIME = 5;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
