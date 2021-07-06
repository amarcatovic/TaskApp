using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace TaskApp.Tasks.Utilities.TokenValidation
{
    public static class TokenValidation
    {
        public static bool ValidateCurrentToken(string token)
        {
            var secret = Environment.GetEnvironmentVariable("TokenSecret");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = securityKey,
                    ClockSkew = TimeSpan.Zero,
                    RequireExpirationTime = false,
                }, out SecurityToken validatedToken);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
	}
}
