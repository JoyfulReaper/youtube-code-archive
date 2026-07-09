using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using MinimalApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace MinimalApi.EndPoints;

public static class AuthenticationEndpoint
{

    public static void AddAuthenticationEndPoints(this WebApplication app)
    {
        app.MapPost("/api/token", (IConfiguration config, [FromBody] AuthenticationData data) =>
        {
            var user = ValidateCredentials(data);

            if (user is null)
            {
                return Results.Unauthorized();
            }

            var token = GenerateToken(user, config);
            return Results.Ok(token);
        });
    }

    private static string GenerateToken(UserData user, IConfiguration config)
    {
        var secretKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(
                config.GetValue<string>("Authentication:SecretKey")));

        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        List<Claim> claims = new();
        claims.Add(new(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
        claims.Add(new(JwtRegisteredClaimNames.UniqueName, user.UserName));
        claims.Add(new(JwtRegisteredClaimNames.GivenName, user.FirstName));
        claims.Add(new(JwtRegisteredClaimNames.FamilyName, user.LastName));


        var token = new JwtSecurityToken(
            config.GetValue<string>("Authentication:Issuer"),
            config.GetValue<string>("Authentication:Audience"),
            claims,
            DateTime.UtcNow,
            DateTime.UtcNow.AddMinutes(1),
            signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static UserData? ValidateCredentials(AuthenticationData data)
    {
        // THIS IS NOT PRODUCTION CODE - REPLACE WITH A CALL TO YOUR AUTH SYSTEM
        if (CompareValues(data.UserName, "kwgivler")
            && CompareValues(data.Password, "Test123"))
        {
            return new UserData(1, "Kyle", "Givler", data.UserName!);
        }

        if (CompareValues(data.UserName, "sstorm")
            && CompareValues(data.Password, "Test123"))
        {
            return new UserData(1, "Sue", "Storm", data.UserName!);
        }

        return null;
    }

    private static bool CompareValues(string? actual, string? expected)
    {
        if (actual is not null)
        {
            if (actual.Equals(expected))
            {
                return true;
            }
        }

        return false;
    }
}
