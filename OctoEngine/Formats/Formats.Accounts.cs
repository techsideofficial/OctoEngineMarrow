using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine.Formats
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)] // Store as a string in MongoDB
        public Guid UUID = Guid.NewGuid();
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Pronouns { get; set; }
        public string PasswordHash { get; set; } // Added property for storing hashed password
        public string Bio { get; set; } // "I'm new here, but haven't written a bio yet!";
        public string Email { get; set; }
        public Region Region { get; set; }
        public bool IsDev { get; set; }
        public bool IsMod { get; set; }
        public int PermLevel { get; set; }
        public ulong DiscordId  { get; set; }
        public AccountLegal Legal { get; set; }
        public AccountGameData GameData { get; set; }
        public List<string> ActiveTokens { get; set; }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Profile
    {
        public string Username { get; set; }
        public string Pronouns { get; set; }
        public string Bio { get; set; }
        public Region Region { get; set; }
        public bool IsDev { get; set; }
        public bool IsMod { get; set; }
    }
}
