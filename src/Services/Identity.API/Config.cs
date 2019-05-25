// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityAPI
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                //new IdentityResources.OpenId(),
                //new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("bankingapi", "Banking API")
                {
                    ApiSecrets = new List<Secret>
                    {
                        new Secret("fU7fRb+g6YdlniuSqviOLWNkda1M/MuPtH6zNI9inF8=")
                    }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                // client credentials flow client
                new Client
                {
                    ClientId = "bankingapiclient",
                    ClientName = "banking api client",
                    ClientSecrets = {new Secret("fU7fRb+g6YdlniuSqviOLWNkda1M/MuPtH6zNI9inF8=")},     
                    
                    RedirectUris = { "" },
                    PostLogoutRedirectUris = { "" },
                
                    RequireClientSecret = false,
                
                    AllowedGrantTypes = {
                        GrantType.ResourceOwnerPassword,
                        GrantType.AuthorizationCode
                    },
                    RequirePkce = true,
                    AllowedScopes = { "openid", "profile", "email", "bankingapi" },
                
                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.ReUse
                },

                // MVC client using hybrid flow
                //new Client
                //{
                //    ClientId = "mvc",
                //    ClientName = "MVC Client",

                //    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                //    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                //    RedirectUris = { "http://localhost:5001/signin-oidc" },
                //    FrontChannelLogoutUri = "http://localhost:5001/signout-oidc",
                //    PostLogoutRedirectUris = { "http://localhost:5001/signout-callback-oidc" },

                //    AllowOfflineAccess = true,
                //    AllowedScopes = { "openid", "profile", "api1" }
                //},

                // SPA client using implicit flow
                //new Client
                //{
                //    ClientId = "spa",
                //    ClientName = "SPA Client",
                //    ClientUri = "http://identityserver.io",

                //    AllowedGrantTypes = GrantTypes.Implicit,
                //    AllowAccessTokensViaBrowser = true,

                //    RedirectUris =
                //    {
                //        "http://localhost:5002/index.html",
                //        "http://localhost:5002/callback.html",
                //        "http://localhost:5002/silent.html",
                //        "http://localhost:5002/popup.html",
                //    },

                //    PostLogoutRedirectUris = { "http://localhost:5002/index.html" },
                //    AllowedCorsOrigins = { "http://localhost:5002" },

                //    AllowedScopes = { "openid", "profile", "api1" }
                //}
            };
        }
    }
}