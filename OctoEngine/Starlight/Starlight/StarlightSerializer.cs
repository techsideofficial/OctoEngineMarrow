using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starlight
{
    public static class StarlightSerializer
    {
        public static StarlightFormat DecodeStarlight(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input cannot be null or empty.", nameof(input));

            try
            {
                string decodedString = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(input));
                var result = JsonConvert.DeserializeObject<StarlightFormat>(decodedString);
                return result ?? throw new InvalidOperationException("Deserialization returned null.");
            }
            catch (Exception ex)
            {
                throw new FormatException("Failed to decode Starlight data.", ex);
            }
        }

        public static string EncodeStarlight(StarlightFormat input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            string jsonString = JsonConvert.SerializeObject(input);
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(jsonString));
        }

        public static StarlightFormat DecodeStarlightJson(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input cannot be null or empty.", nameof(input));

            try
            {
                var result = JsonConvert.DeserializeObject<StarlightFormat>(input);
                return result ?? throw new InvalidOperationException("Deserialization returned null.");
            }
            catch (Exception ex)
            {
                throw new FormatException("Failed to decode Starlight data.", ex);
            }
        }

        public static string EncodeStarlightJson(StarlightFormat input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            string jsonString = JsonConvert.SerializeObject(input);
            return jsonString;
        }
    }
}
