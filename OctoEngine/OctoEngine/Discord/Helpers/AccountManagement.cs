using CompileTimeObfuscator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine.Discord.Helpers
{
    public static partial class AccountManagement
    {
        // Remove obfuscation, why the fuck did I leave it in????
        // [ObfuscatedString("1333302713492045865")]
        // private static partial string OClientId(); // huh????? was broken before!

        private static string OClientId = "1333302713492045865";

        public static string Authorise()
        {
            //var discordClient = new Core.DiscordCore(
            //    clientId: OClientId(),
            //    clientSecret: "YOUR_CLIENT_SECRET",
            //    redirectUri: "http://localhost:5000/callback"
            //);

            //string authUrl = discordClient.GetAuthorizationUrl("guilds guilds.channels.read guilds.members.read presences.read identify");
            //Utils.Logging.LogMessage($"Login via: {authUrl}");

            //return authUrl;

            throw new NotImplementedException(); // buggy
        }
    }
}
