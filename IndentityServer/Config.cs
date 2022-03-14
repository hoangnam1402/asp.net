﻿using IdentityServer4;
using IdentityServer4.Models;

namespace Indentity
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
             new IdentityResource("roles", new[] { "role" }) //Add this line
        };

        public static IEnumerable<ApiScope> ApiScopes =>
            new[] {
                new ApiScope("api1", "https://localhost:5003")
            };


        public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            // machine to machine client (from quickstart 1)
            new Client
            {
                ClientId = "client",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.ClientCredentials ,
                // scopes that client has access to
                AllowedScopes = { "api1" }
            },
            // interactive ASP.NET Core MVC client
            new Client
            {
                 ClientName = "Rookie.Ecom.MetaShop.mvc",
                   ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    // where to redirect to after login
                    RedirectUris = { "https://localhost:5002/signin-oidc" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                    // Enable refresh token
                    AllowOfflineAccess = true,

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles"
                    }
            },
            new Client
            {
                ClientName ="Rookie.Ecom.MetaShop.Admin",
                ClientId = "rookieecom",
                ClientSecrets = {new Secret("rookieecom".Sha256()) },
                AllowedGrantTypes = GrantTypes.Implicit ,
                RedirectUris = new List<string>()
                    {
                        "https://localhost:3000/callback",
                        "https://localhost:5000/callback"
                    },
                 PostLogoutRedirectUris = new List<string>()
                    {
                        "https://localhost:3000/",
                        "https://localhost:5003/"
                    },

                  AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles"
                    },
                  AllowAccessTokensViaBrowser = true
            }
        };
    }
}
