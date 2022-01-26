using System;
using System.Collections.Generic;
using System.Text;

namespace TokenConsoleApp
{
    public class AuthSettings
    {
        public const string ConfigurationName = "Authentication";

        public string Authority { get; set; }
        public string ApiName { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AccessScope { get; set; }
    }
}
