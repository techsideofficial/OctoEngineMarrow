using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace OctoEngine.Formats
{
    public class AuraGuildSettings
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id = Guid.NewGuid();
        public bool IsCreated { get; set; }

        public string GuildId { get; set; }
        public bool Banned { get; set; }

        public bool IsDevGuild { get; set; }
        public bool IsSpecialGuild { get; set; }
        public bool IsApprovedGuild { get; set; }
        public bool IsDevSupportedCommunityGuild { get; set; }
        public bool IsStubGuild { get; set; }
        public bool IsStarlightSkyGuild { get; set; }

        public bool IsCuratedCommunityGuild { get; set; }
        public int GuildCurationRanking { get; set; }

        public string AuraUserRoleId { get; set; }
        public string AuraBannedRoleId { get; set; }
        public string GuildAdminRoleId { get; set; }
    }

    public enum AuraRole
    {
        AuraUser,
        AuraBanned,
        GuildAdmin
    }

    public class AuraGlobalSettings
    {
        public List<string> GlobalAdmins { get; set; }
    }

    public class AuraGuildSettingsAPI
    {
        public string AuraUserRoleId { get; set; }
        public string AuraBannedRoleId { get; set; }
        public string GuildAdminRoleId { get; set; }
    }

    public class AuraUserAccount
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id = Guid.NewGuid();
        public string DiscordId { get; set; }
        public string Username { get; set; }
        public bool IsBanned { get; set; }
        public bool IsRestricted { get; set; }
        public int RestrictionLevel { get; set; }
        public bool IsDev { get; set; }
        public bool IsMod { get; set; }
        public bool IsApproved { get; set; }
        public bool IsStarlightSky { get; set; }
        public object SplitTestingData { get; set; }
        public object Metadata { get; set; }

        public AuraCommandPermissionCalculationInternal GetPermissions()
        {
            var permissions = new AuraCommandPermissionCalculationInternal();
            permissions.FromPermissionInteger(RestrictionLevel);
            return permissions;
        }

        public void SetPermissions(AuraCommandPermissionCalculationInternal permissions)
        {
            RestrictionLevel = permissions.ToPermissionInteger();
        }
    }

    // Metadata-specific classes
    public class AuraGlobalCommandCooldown
    {
        public int CooldownDuration { get; set; }
        public DateTime CooldownEndDate { get; set; }
    }

    // Metadata-specific responses
    public class CoolDownState
    {
        public int CoolDownSecondsLeft { get; set; }
    }

    public class AuraCommandPermissionCalculationInternal
    {
        public bool InfoCommands { get; set; }
        public bool FunCommands { get; set; }
        public bool AttackCommands { get; set; }
        public bool AICommands { get; set; }

        private const int InfoCommandsBit = 1 << 0; // 1
        private const int FunCommandsBit = 1 << 1; // 2
        private const int AttackCommandsBit = 1 << 2; // 4
        private const int AICommandsBit = 1 << 3; // 8

        public int ToPermissionInteger()
        {
            int permissionInteger = 0;
            if (InfoCommands) permissionInteger |= InfoCommandsBit;
            if (FunCommands) permissionInteger |= FunCommandsBit;
            if (AttackCommands) permissionInteger |= AttackCommandsBit;
            if (AICommands) permissionInteger |= AICommandsBit;
            return permissionInteger;
        }

        public void FromPermissionInteger(int permissionInteger)
        {
            InfoCommands = (permissionInteger & InfoCommandsBit) != 0;
            FunCommands = (permissionInteger & FunCommandsBit) != 0;
            AttackCommands = (permissionInteger & AttackCommandsBit) != 0;
            AICommands = (permissionInteger & AICommandsBit) != 0;
        }
    }

    public class AuraServerStatus
    {
        public string ServerCodeName { get; set; }
        public List<string> AuraShardIds { get; set; }
        public List<string> FreyaShardIds { get; set; }
        public string Performance { get; set; }
        public string ServerEnvironment { get; set; }
        public object Metadata { get; set; }
    }

    public class AuraEvent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool ManualEvent { get; set; }
        public bool IsActive { get; set; }
        public int DurationSecs { get; set; }
        public AuraReward EventCompleteReward { get; set; }
        public bool IsRecurring { get; set; }

    }

    public class AuraReward
    {
        public string RewardId { get; set; }
        public int RewardAmount { get; set; }
    }

    public class Fleet
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id = Guid.NewGuid();
        
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public int LevelRequired { get; set; }
        public bool Unlocked { get; set; }
        public List<string> Members { get; set; }
    }

    public class Group
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id = Guid.NewGuid();
        
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public bool Unlocked { get; set; }
        public List<string> Members { get; set; }
    }

    public class AIHistoryPerUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id = Guid.NewGuid();

        public string DiscordId { get; set; }
        public List<AIChatEntry> History { get; set; }
    }
    
    public enum GroupOperationType
    {
        AddUser,
        RemoveUser,
    }

    public class GroupLists
    {
        public List<Group> AllGroups { get; set; }
        public List<Group> GroupsUserIsIn { get; set; }
        public List<Group> GroupsUserIsNotIn { get; set; }
    }
}
