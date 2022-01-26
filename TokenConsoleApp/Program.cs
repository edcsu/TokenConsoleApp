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
            var token = await TokenHelper.GetAuthorizeToken();
            var tokenDetails = JsonConvert.DeserializeObject<TokenResponse>(token);
            Console.WriteLine($"Access token: {tokenDetails.AccessToken}");
            Console.WriteLine($"Expires In: {tokenDetails.ExpiresIn} seconds");
            Console.WriteLine($"TokenType: {tokenDetails.TokenType}");
            Console.WriteLine($"Scope: {tokenDetails.Scope}");
        }
    }
}
