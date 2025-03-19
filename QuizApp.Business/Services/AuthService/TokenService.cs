using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.UnitOfWork;

namespace QuizApp.Business.Services.AuthService;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly SymmetricSecurityKey _key;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"] ?? "supersecuredsecretkey"));
    }

    public async Task<string> GenerateTokenAsync(User user, IList<string> userRoles)
    {
        // Create claims for the token
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, user.UserName ?? string.Empty),
            new(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
            new("fullName", user.DisplayName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // Add role claims
        claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

        // Create credentials using the secret key
        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

        // Get token expiration from config (default to 15 minutes)
        if (!int.TryParse(_configuration["JWT:AccessTokenExpiryMinutes"], out var expiryMinutes))
        {
            expiryMinutes = 15;
        }
        
        // Set token expiration
        var expiry = DateTime.UtcNow.AddMinutes(expiryMinutes);

        // Create the JWT token
        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:Issuer"],
            audience: _configuration["JWT:Audience"],
            claims: claims,
            expires: expiry,
            signingCredentials: creds
        );

        // Return the serialized token
        return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
    }
    
}
