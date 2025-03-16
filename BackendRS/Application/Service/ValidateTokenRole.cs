using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BackendRS.Application.Service
{
    public class ValidateTokenRole
    {
        public bool ValidateRole(string _token)
        {
            var AuthorizedRole = "Admin";

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadToken(_token) as JwtSecurityToken;

            if (jwtToken == null)
            {
                throw new Exception("Nenhum Token recebido");
            }

            var roleClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "role");

            if (roleClaim == null) 
            {
                throw new Exception("Role não encontrada!");
            }

            var role = roleClaim.Value;

            if (role == AuthorizedRole)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
