using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine.Discord.Core
{
    public partial class DiscordCore // DO NOT USE THIS! It is buggy as fuck!
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _redirectUri;

        public DiscordCore(string clientId, string clientSecret, string redirectUri)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _redirectUri = redirectUri;
        }

        public string GetAuthorizationUrl(string scope)
        {
            //return $"https://discord.com/api/oauth2/authorize" +
            //       $"?client_id={_clientId}" +
            //       $"&redirect_uri={_redirectUri}" +
            //       $"&response_type=code" +
            //       $"&scope={scope}";

            throw new NotImplementedException();
        }

        public async Task<string> ExchangeCodeForTokenAsync(string code)
        {
            //    using var client = new HttpClient();
            //    var content = new FormUrlEncodedContent(new[]
            //    {
            //    new KeyValuePair<string, string>("client_id", _clientId),
            //    new KeyValuePair<string, string>("client_secret", _clientSecret),
            //    new KeyValuePair<string, string>("grant_type", "authorization_code"),
            //    new KeyValuePair<string, string>("code", code),
            //    new KeyValuePair<string, string>("redirect_uri", _redirectUri)
            //});

            //    var response = await client.PostAsync("https://discord.com/api/oauth2/token", content);
            //    response.EnsureSuccessStatusCode();
            //    return await response.Content.ReadAsStringAsync();

            throw new NotImplementedException(); // too buggy for prod - prevents accidental usage
        }
    }
}
