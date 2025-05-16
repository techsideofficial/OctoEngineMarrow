using AuroraFramework.TS3Game.Events;
using AuroraFramework.TS3Game.Missions;
using AuroraFramework.TS3Game.RubyRails;
using AuroraFramework.TS3Game.Stagecoach;
using OctoEngine.MarrowFramework.Base;
using OctoEngine.MarrowFramework.Developer;
using OctoEngine.MarrowFramework.ESports;
using OctoEngine.MarrowFramework.Gameplay;
using OctoEngine.MarrowFramework.Games.TS3Game;
using OctoEngine.MarrowFramework.MissionTypes;
using OctoEngine.MarrowFramework.Physics;
using OctoEngine.MarrowFramework.Settings;

namespace OctoEngine.MarrowFramework
{
    public class Injector
    {
        public static void InjectBehaviors()
        {
            // MarrowFramework
            FieldInjector.SerialisationHandler.Inject<OctoManager>();

            // MarrowFramework Base
            FieldInjector.SerialisationHandler.Inject<AICharacter>();
            FieldInjector.SerialisationHandler.Inject<AreaGates>();
            FieldInjector.SerialisationHandler.Inject<AudioSystem>();
            FieldInjector.SerialisationHandler.Inject<DedupeCache>();
            FieldInjector.SerialisationHandler.Inject<DeveloperWaypoint>();
            FieldInjector.SerialisationHandler.Inject<MissionSystem>();
            FieldInjector.SerialisationHandler.Inject<NotificationSender>();
            FieldInjector.SerialisationHandler.Inject<OctoPlayerRig>();

            // MarrowFramework Developer
            FieldInjector.SerialisationHandler.Inject<EngineDebug>();
            FieldInjector.SerialisationHandler.Inject<DebugObjectDiscriminator>();
            FieldInjector.SerialisationHandler.Inject<DebugUI>();
            FieldInjector.SerialisationHandler.Inject<DebugMachine>();

            // MarrowFramework ESports
            FieldInjector.SerialisationHandler.Inject<ES_Game_Manager>();
            FieldInjector.SerialisationHandler.Inject<ES_Game_Clock>();
            FieldInjector.SerialisationHandler.Inject<ES_Goal>();

            // MarrowFramework Gameplay
            FieldInjector.SerialisationHandler.Inject<GPSpawnLocation>();

            // MarrowFramework MissionTypes
            FieldInjector.SerialisationHandler.Inject<MissionType_CollectObjects>();
            FieldInjector.SerialisationHandler.Inject<MissionType_ZoneContainment>();

            // MarrowFramework Physics
            FieldInjector.SerialisationHandler.Inject<PhysicsInteractionSender>();
            FieldInjector.SerialisationHandler.Inject<PhysicsInteractionReciever>();

            // MarrowFramework Settings
            FieldInjector.SerialisationHandler.Inject<SettingsBasedMultiObjectDiscriminator>();

            // MarrowFramework Games - TS3Game - Legacy
            FieldInjector.SerialisationHandler.Inject<MissionCompleteEvent>();

            FieldInjector.SerialisationHandler.Inject<CowbellManager>();
            FieldInjector.SerialisationHandler.Inject<CowbellMission>();
            FieldInjector.SerialisationHandler.Inject<FourCowsMission>();

            FieldInjector.SerialisationHandler.Inject<RubyRailsSeater>();
            FieldInjector.SerialisationHandler.Inject<RubyRailsManager>();

            FieldInjector.SerialisationHandler.Inject<StagecoachAnimator>();
            FieldInjector.SerialisationHandler.Inject<StageCoachGate>();
            FieldInjector.SerialisationHandler.Inject<StagecoachGiftBox>();
            FieldInjector.SerialisationHandler.Inject<StagecoachGiftData>();
            FieldInjector.SerialisationHandler.Inject<StagecoachGiftItem>();
            FieldInjector.SerialisationHandler.Inject<StagecoachManager>();
            FieldInjector.SerialisationHandler.Inject<StagecoachGifter>();

            // MarrowFramework Games - TS3Game - New
            FieldInjector.SerialisationHandler.Inject<Townsfolk>();
        }
    }
}
