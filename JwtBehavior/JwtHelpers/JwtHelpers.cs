using JwtBehavior.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace JwtBehavior.JwtHelpers
{
    public static class JwtHelpers
    {
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts)
        {
            IEnumerable<Claim> claims = new Claim[]
            {
                new Claim("Id",userAccounts.Id.ToString(),ClaimValueTypes.Integer64),
                new Claim("Email",userAccounts.Email),
                new Claim("Owner",userAccounts.IsOwner.ToString(),ClaimValueTypes.Boolean),
                new Claim(ClaimTypes.Expiration,DateTime.UtcNow.AddDays(1).ToString(),ClaimValueTypes.DateTime)
            };
            return claims;
        }
        public static UserTokens GenTokenKey(UserTokens model,JwtSettings jwtSettings)
        {
            try
            {
                UserTokens userTokens = new UserTokens();
                if (model == null) throw new ArgumentNullException(nameof(model));

                    byte[] key = Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);
                    Guid Id = Guid.Empty;
                    DateTime expireTime = DateTime.UtcNow.AddDays(1);


                    JwtSecurityToken JWTToken = new JwtSecurityToken(
                        issuer: jwtSettings.ValidIssuer,
                        audience: jwtSettings.ValidAudience,
                        claims:GetClaims(model),
                        notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                        expires: new DateTimeOffset(expireTime).DateTime,
                        signingCredentials: new SigningCredentials(
                            new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256
                            ));
                
                    userTokens.Token = new JwtSecurityTokenHandler().WriteToken(JWTToken);
                    userTokens.IsOwner= model.IsOwner;
                    userTokens.Id = model.Id;

                    return userTokens;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}
