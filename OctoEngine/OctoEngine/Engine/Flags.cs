using ConfigCat.Client;
using dotenv.net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine.Engine
{
    public class Flags
    {
        private static async Task<object> GetFlagInternal(string flagName, object defaultValue, string userId)
        {
            User userObject = new User(userId);

            var client = ConfigCatClient.Get("null"); // <-- This is the actual SDK Key for your 'Test Environment' environment
            client.LogLevel = LogLevel.Info; // <-- Set the log level to INFO to track how your feature flags were evaluated. When moving to production, you can remove this line to avoid too detailed logging.

            return await client.GetValueAsync(flagName, defaultValue, userObject);
        }

        public static string GetFlag(string flagName, string defaultValue, string userId)
        {
            return (string)GetFlagInternal(flagName, defaultValue, userId).Result;
        }

        public static bool GetFlag(string flagName, bool defaultValue, string userId)
        {
            return (bool)GetFlagInternal(flagName, defaultValue, userId).Result;
        }

        public static int GetFlag(string flagName, int defaultValue, string userId)
        {
            return (int)GetFlagInternal(flagName, defaultValue, userId).Result;
        }

        public static float GetFlag(string flagName, float defaultValue, string userId)
        {
            return (float)GetFlagInternal(flagName, defaultValue, userId).Result;
        }
    }
}
