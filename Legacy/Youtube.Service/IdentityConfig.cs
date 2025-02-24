using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Youtube.Service;

public static class IdentityConfig
{
    public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var authOptions = configuration.GetSection(AuthOptions.Auth).Get<AuthOptions>();
        const string AUTH = "auth";
        services.AddHttpClient(AUTH, options =>
        {
            options.BaseAddress = new Uri(authOptions.JWKSUri);
        });
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.MapInboundClaims = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = true,
                    ValidIssuer = authOptions.Issuer,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromSeconds(30),
                    
                    ValidateIssuerSigningKey = true,
                    ValidAudience = authOptions.Audience,
                    IssuerSigningKeyResolver = (_, _, _, _) =>
                    {
                        var httpClient = services.BuildServiceProvider().GetRequiredService<IHttpClientFactory>().CreateClient(AUTH);
                        var keysJson = httpClient.GetStringAsync("").Result;
                        return new JsonWebKeySet(keysJson).GetSigningKeys();
                    }
                };
            });
    }
}

public record AuthOptions
{
    public const string Auth = "Auth";
    public string JWKSUri { get; set; }
    public string Audience { get; set; }
    public string Issuer { get; set; }
}