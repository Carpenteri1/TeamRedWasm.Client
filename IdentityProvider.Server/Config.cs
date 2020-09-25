﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace IdentityProvider.Server
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };


        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
            };


        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName ="TeamRed Client Server",
                    ClientId = "teamredclientserver",
                    AllowedGrantTypes = GrantTypes.Code,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    RedirectUris = new List<string>()//where the client will get tokens from.
                    {
                        //client host adress for signing in 
                       "https://localhost:44339/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                           //client host adress for signing out
                         "https://localhost:44339/signout-callback-oidc"
                    },
                    AllowedScopes = 
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                   // AllowOfflineAccess = true,
                    ClientSecrets = 
                    {
                        //Secret is used for client authentication 
                        //so the client can call the token endpoint
                        new Secret("superSecret".Sha256())
                    }
                }};
    }
}