using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace GeekShopping.IdentityServer.Configuration;

public static class IdentityConfiguration
{
    public const string Admin = "Admin";
    public const string Client = "Client";
    
    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
        };
    
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("geek_shopping", "GeekShopping Server"),
            new ApiScope("read", "Read Data"),
            new ApiScope("write", "Write Data"),
            new ApiScope("delete", "Delete Data")
        };
    
    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("geek_shopping_secret".Sha256())},
                AllowedScopes = {"profile", "read", "write"}
            },
            new Client
            {
                ClientId = "geek_shopping",
                AllowedGrantTypes = GrantTypes.Code,
                ClientSecrets = {new Secret("geek_shopping_secret".Sha256())},
                RedirectUris = {"https://localhost:7215/signin_oidc"},
                PostLogoutRedirectUris = {"https://localhost:7215/signout-callback-oidc"},
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "geek_shopping"
                }
            }
        };
}