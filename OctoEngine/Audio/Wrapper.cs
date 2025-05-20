using System;
using FMOD;
using FMOD.Studio;
using OctoEngine.Utils;
using OctoEngine.Debugging;
using Timer = System.Timers.Timer;
using System.Timers;

namespace OctoEngine.Audio
{
    public class FMODAudioSystem
    {
        private FMOD.Studio.System studioSystem;
        private EventDescription eventDescription;
        private EventInstance eventInstance;
        private Bank masterBank;
        private Bank masterStringsBank;
        private Bank musicBank;
        private Bank sfxBank;
        private Bank voBank;
        private Timer _updateTimer;

        public enum MixerType
        {
            Bus,
            VCA
        }

        public FMODAudioSystem()
        {
            // Initialize FMOD Studio System
            FMOD.Studio.System.create(out studioSystem);
            studioSystem.initialize(1024, FMOD.Studio.INITFLAGS.NORMAL, FMOD.INITFLAGS.NORMAL, IntPtr.Zero);

            _updateTimer = new Timer(16); // ~60 FPS (ENGINE LOCKED)
            _updateTimer.Elapsed += OnUpdate;
            _updateTimer.AutoReset = true;
            _updateTimer.Start();
        }

        private void OnUpdate(object sender, ElapsedEventArgs e)
        {
            studioSystem.update();
        }

        public void LoadBanks(string bankFolderPath)
        {
            // TODO: Prevent dupilicate banks
            // Add global loading
            // Load all necessary banks
            studioSystem.loadBankFile(System.IO.Path.Combine(bankFolderPath, "Master.bank"), LOAD_BANK_FLAGS.NORMAL, out masterBank);
            studioSystem.loadBankFile(System.IO.Path.Combine(bankFolderPath, "Master.strings.bank"), LOAD_BANK_FLAGS.NORMAL, out masterStringsBank);
            studioSystem.loadBankFile(System.IO.Path.Combine(bankFolderPath, "Music.bank"), LOAD_BANK_FLAGS.NORMAL, out musicBank);
            studioSystem.loadBankFile(System.IO.Path.Combine(bankFolderPath, "SFX.bank"), LOAD_BANK_FLAGS.NORMAL, out sfxBank);
            studioSystem.loadBankFile(System.IO.Path.Combine(bankFolderPath, "VO.bank"), LOAD_BANK_FLAGS.NORMAL, out voBank);
        }

        public void PlayEvent(string eventPath)
        {
            // Retrieve event description
            studioSystem.getEvent(eventPath, out eventDescription);
            eventDescription.createInstance(out eventInstance);
            eventInstance.start();
        }

        public void StopEvent()
        {
            eventInstance.stop(STOP_MODE.IMMEDIATE);
        }

        public void Update() // Manual update for engine takeovers
        {
            studioSystem.update();
        }

        public void Release()
        {
            eventInstance.release();
            masterBank.unload();
            masterStringsBank.unload();
            musicBank.unload();
            sfxBank.unload();
            voBank.unload();
            studioSystem.release();
        }

        /// <summary>
        /// Sets the parameter value of an event.
        /// </summary>
        /// <param name="parameter">The parameter name.</param>
        /// <param name="value">The parameter value (as a label).</param>
        public void SetParameter(string parameter, string value)
        {
            float outValue;

            studioSystem.getParameterByName(parameter, out outValue);
            Logging.LogMessage("Current value of parameter " + parameter + " is " + outValue);
            studioSystem.setParameterByNameWithLabel(parameter, value);
            Logging.LogMessage("New value is " + value);
        }

        /// <summary>
        /// Sets the parameter value of an event.
        /// </summary>
        /// <param name="parameter">The parameter name.</param>
        /// <param name="value">The parameter value (as a numerical value).</param>
        public void SetParameter(string parameter, float value)
        {
            studioSystem.setParameterByName(parameter, value);
        }

        public void SetMixerVolume(MixerType m, string path, float volume)
        {
            Bus bus = new();
            VCA vca = new();
            float currVolume;

            if (m == MixerType.Bus)
            {
                studioSystem.getBus(path, out bus);
                Logging.LogMessage("Getting volume of bus " + path);
                bus.getVolume(out currVolume);
                Logging.LogMessage("Current bus volume is " + currVolume);
                bus.setVolume(volume);
                Logging.LogMessage("New bus volume is " + currVolume);
            }
            else if (m == MixerType.VCA)
            {
                studioSystem.getVCA(path, out vca);
                Logging.LogMessage("Getting volume of VCA " + path);
                vca.getVolume(out currVolume);
                Logging.LogMessage("Current VCA volume is " + currVolume);
                vca.setVolume(volume);
                Logging.LogMessage("New VCA volume is " + currVolume);
            }
            else
            {
                CrashHandler.InitiateCrash("An unknown MixerType was specified. " +
                        "This should not happen!");
            }
        }
    }
}
