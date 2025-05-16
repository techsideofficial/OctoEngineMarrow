using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine.Discord.Core
{
    public partial class DiscordCore
    {
        public async Task<string> GetUserGuildsAsync(string accessToken)
        {
            //using var client = new HttpClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            //var response = await client.GetAsync("https://discord.com/api/v10/users/@me/guilds");
            //response.EnsureSuccessStatusCode();
            //return await response.Content.ReadAsStringAsync();

            throw new NotImplementedException(); // Adding this because it's too buggy for prod
        }

        public async Task<string> GetGuildEventsAsync(string accessToken, string guildId)
        {
            //using var client = new HttpClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            //var response = await client.GetAsync($"https://discord.com/api/v10/guilds/{guildId}/scheduled-events");
            //response.EnsureSuccessStatusCode();
            //return await response.Content.ReadAsStringAsync();

            throw new NotImplementedException();
        }
    }
}
