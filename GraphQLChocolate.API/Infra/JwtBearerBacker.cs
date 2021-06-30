using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;

namespace GraphQLChocolate.API.Infra
{
    public class JwtBearerBacker
    {
        private readonly JwtBearerOptions _options;

        public JwtBearerBacker(JwtBearerOptions options)
        {
            _options = options;
        }

        public ClaimsPrincipal IsJwtValid(string token)
        {
            foreach (var validator in _options.SecurityTokenValidators)
            {
                if (validator.CanReadToken(token))
                {
                    try
                    {
                        var claims = validator
                            .ValidateToken(token, _options.TokenValidationParameters, out SecurityToken validatedToken);

                        return claims;
                    }
                    catch (Exception ex)
                    {
                        // If the keys are invalid, refresh config
                        if (_options.RefreshOnIssuerKeyNotFound && _options.ConfigurationManager != null
                            && ex is SecurityTokenSignatureKeyNotFoundException)
                        {
                            _options.ConfigurationManager.RequestRefresh();
                        }

                        continue;
                    }
                }
            }

            return null;
        }
    }
}
