using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace TokenConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Getting token from AuthService");

            // Build a config object, using env vars and JSON providers.
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            // Get AuthServiceSettings values from the config.
            var settings = config.GetRequiredSection(AuthSettings.ConfigurationName).Get<AuthSettings>();

            Console.WriteLine($"Accessing: {settings.Authority}");
            var tokenResult = await TokenHelper.GetAuthorizeToken(settings);
            var tokenDetails = JsonConvert.DeserializeObject<TokenResponse>(tokenResult);
            Console.WriteLine($"Access token: {tokenDetails.AccessToken}");
            Console.WriteLine($"Expires In: {tokenDetails.ExpiresIn} seconds");
            Console.WriteLine($"TokenType: {tokenDetails.TokenType}");
            Console.WriteLine($"Scope: {tokenDetails.Scope}");
        }
    }
}
