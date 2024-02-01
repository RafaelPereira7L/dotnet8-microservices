using System.Security.Claims;
using GeekShopping.IdentityServer.Configuration;
using GeekShopping.IdentityServer.Model;
using GeekShopping.ProductAPI.Contexts;
using IdentityModel;
using Microsoft.AspNetCore.Identity;

namespace GeekShopping.IdentityServer.Initializer;

public class DbInitializer : IDbInitializer
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    
    public DbInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public void Initialize()
    {
        if (_roleManager.FindByNameAsync(IdentityConfiguration.Admin).Result != null) return;

        _roleManager.CreateAsync(new IdentityRole(IdentityConfiguration.Admin)).GetAwaiter().GetResult();
        _roleManager.CreateAsync(new IdentityRole(IdentityConfiguration.Client)).GetAwaiter().GetResult();

        var adminUser = new ApplicationUser
        {
            UserName = "admin",
            Email = "admin@email.com",
            EmailConfirmed = true,
            PhoneNumber = "+55 11 99999-9999",
            FirstName = "Rafael",
            LastName = "Admin"
        };

        _userManager.CreateAsync(adminUser, "Admin@123").GetAwaiter().GetResult();
        _userManager.AddToRoleAsync(adminUser, IdentityConfiguration.Admin).GetAwaiter().GetResult();

        var adminClaims = _userManager.AddClaimsAsync(adminUser, new Claim[]
        {
            new Claim(JwtClaimTypes.Name, $"{adminUser.FirstName} {adminUser.LastName}"),
            new Claim(JwtClaimTypes.GivenName, adminUser.FirstName),
            new Claim(JwtClaimTypes.FamilyName, adminUser.LastName),
            new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin),
            
        }).Result;
        
        var clientUser = new ApplicationUser
        {
            UserName = "client",
            Email = "client@email.com",
            EmailConfirmed = true,
            PhoneNumber = "+55 11 99999-9999",
            FirstName = "Rafael",
            LastName = "Client"
        };

        _userManager.CreateAsync(clientUser, "Client@123").GetAwaiter().GetResult();
        _userManager.AddToRoleAsync(adminUser, IdentityConfiguration.Client).GetAwaiter().GetResult();

        var clientClaims = _userManager.AddClaimsAsync(adminUser, new Claim[]
        {
            new Claim(JwtClaimTypes.Name, $"{clientUser.FirstName} {clientUser.LastName}"),
            new Claim(JwtClaimTypes.GivenName, clientUser.FirstName),
            new Claim(JwtClaimTypes.FamilyName, clientUser.LastName),
            new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client),
            
        }).Result;
    }
}