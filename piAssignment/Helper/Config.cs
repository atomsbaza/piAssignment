using System;
using IdentityServer4.Models;

namespace piAssignment.Helper
{
	public static class Config
	{
        public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "https://localhost:7269/",
                ClientSecrets = { new Secret("your_client_secret".Sha256()) }, // Not surw where to get it
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "api" }
            }
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("api", "Your API")
            };
    }
}

