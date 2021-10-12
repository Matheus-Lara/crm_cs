using System;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

using TesteClasses.Models;

namespace TesteClasses.Services {

  public static class TokenService {

    public static string GerarToken(UsuarioModel usuario){

      var tokenHandler = new JwtSecurityTokenHandler();
      var appKey = Encoding.ASCII.GetBytes(AppKey.Key);
      var tokenDescriptor = new SecurityTokenDescriptor 
      {
        Subject = new ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.Name, usuario.Login.ToString()), 
          new Claim(ClaimTypes.Role, usuario.Vendedor.ToString())
        }),
        Expires = DateTime.UtcNow.AddHours(2),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(appKey), 
                    SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }
  }
}
