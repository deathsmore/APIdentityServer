// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace NewCore.IDP
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource(
                    "permission",
                    "Your permission(s)",
                    new List<string>() { "permission" }),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("DVG.AutoPortal.CMS.CarInfo", "DVG AutoPortal CMS CarInfo")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("DVG.AutoPortal.CMS.CarInfo", "DVG AutoPortal CMS CarInfo")
                {
                    Scopes = { "DVG.AutoPortal.CMS.CarInfo" }
                }
            };
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client()
                {
                    ClientName = "DVG AutoPortal CMS Client",
                    ClientId =  "DVG.AutoPortal.CMS.Spa",
                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    RedirectUris = { 
                        "http://localhost:4200/signin-callback", 
                        "http://localhost:4200/assets/silent-callback.html" 
                    },
                    PostLogoutRedirectUris = { 
                        "http://localhost:4200/signout-callback" 
                    },
                    AllowedCorsOrigins = { 
                        "http://localhost:4200" 
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "permission",
                        "DVG.AutoPortal.CMS.CarInfo"
                    },
                    ClientSecrets =
                    {
                        new Secret("DVG.AutoPortal.CMS.Spa".Sha256())
                    },
                    AccessTokenLifetime = 600
                }
            };
    }
}