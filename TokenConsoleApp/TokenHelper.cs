using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace TokenConsoleApp
{
    internal static class TokenHelper
    {
        public static async Task<string> GetAuthorizeToken(AuthSettings settings)
        {
            // Posting.  
            using var client = new HttpClient();

            // Setting AuthService URL.  
            client.BaseAddress = new Uri(settings.Authority);

            // Setting content type.  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));

            // Initialization.  
            List<KeyValuePair<string, string>> allIputParams = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", settings.ClientId), 
                new KeyValuePair<string, string>("client_secret", settings.ClientSecret), 
            };

            // Convert Request Params to Key Value Pair.  

            // URL Request parameters.  
            HttpContent requestParams = new FormUrlEncodedContent(allIputParams);

            // HTTP POST  
            var response = await client.PostAsync("connect/token", requestParams);

            // Initialization.  
            string responseObj;
            // Verification  
            if (response.IsSuccessStatusCode)
            {
                responseObj = await response.Content.ReadAsStringAsync();
            }
            else
            {
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw new ApplicationException("Failed to get access token");
            }

            return responseObj;
        }
    }
}
