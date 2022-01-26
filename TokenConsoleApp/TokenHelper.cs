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
        public static async Task<string> GetAuthorizeToken()
        {
            // Initialization.  
            string responseObj = string.Empty;

            // Posting.  
            using var client = new HttpClient();

            // Setting AuthService URL.  
            client.BaseAddress = new Uri("https://auth-api-test.streamline.laboremus.ug/");

            // Setting content type.  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));

            // Initialization.  
            List<KeyValuePair<string, string>> allIputParams = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", string.Empty), // replace with clientid
                new KeyValuePair<string, string>("client_secret", string.Empty), //replace with client secret
            };

            // Convert Request Params to Key Value Pair.  

            // URL Request parameters.  
            HttpContent requestParams = new FormUrlEncodedContent(allIputParams);

            // HTTP POST  
            var response = await client.PostAsync("connect/token", requestParams);

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
