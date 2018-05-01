using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;

namespace Samples.WebApi.Security
{
    /// <summary>
    /// The B2CSecurityTokenValidator class.
    /// </summary>
    public class B2CSecurityTokenValidator : ISecurityTokenValidator
    {
        private readonly ConfigurationManager<OpenIdConnectConfiguration> _configManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="B2CSecurityTokenValidator"/> class.
        /// </summary>
        public B2CSecurityTokenValidator(string tenantId, string policy)
        {
            if (tenantId == null)
            {
                throw new ArgumentNullException(nameof(tenantId));
            }
            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }

            Issuer = CreateIssuer(tenantId);
            _configManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                CreateMetaAddress(tenantId, policy),
                new OpenIdConnectConfigurationRetriever());
        }

        /// <summary>
        /// Get can validate token.
        /// </summary>
        public bool CanValidateToken => true;

        /// <summary>
        /// Get issuer.
        /// </summary>
        public string Issuer { get; }

        /// <summary>
        /// Gets and sets MaximumTokenSizeInBytes.
        /// </summary>
        public int MaximumTokenSizeInBytes { get; set; }

        /// <summary>
        /// Can read token.
        /// </summary>
        public bool CanReadToken(string securityToken)
        {
            var jwt = new JwtSecurityToken(securityToken);
            return Issuer.Equals(jwt.Issuer, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Validate token.
        /// </summary>
        public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            var openIdConfig = _configManager.GetConfigurationAsync(CancellationToken.None).Result;

            var handler = new JwtSecurityTokenHandler();
            validationParameters.IssuerSigningKeys = openIdConfig.SigningKeys;
            var user = handler.ValidateToken(securityToken, validationParameters, out validatedToken);

            return user;
        }

        /// <summary>
        /// Create issuer.
        /// </summary>
        private static string CreateIssuer(string tenantId)
            => $"https://login.microsoftonline.com/{tenantId}/v2.0/";

        /// <summary>
        /// Create meta address.
        /// </summary>
        private static string CreateMetaAddress(string tenantId, string policy)
            => $"https://login.microsoftonline.com/{tenantId}/v2.0/.well-known/openid-configuration?p={policy}";
    }
}