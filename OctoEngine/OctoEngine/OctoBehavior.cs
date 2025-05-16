using System;
using System.Reflection;
using System.Timers;
using Timer = System.Timers.Timer;

namespace OctoEngine
{
    public class OctoBehavior : IDisposable
    {
        private Timer _updateTimer;
        private Action _updateMethod;
        private Action _startMethod;
        private bool _isRunning = true; // Controls update loop

        public OctoBehavior()
        {
            // Look for parameterless Start & Update methods in the derived class
            MethodInfo startMethodInfo = GetType().GetMethod("Start", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly);
            MethodInfo updateMethodInfo = GetType().GetMethod("Update", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly);

            _startMethod = startMethodInfo != null
                ? (Action)Delegate.CreateDelegate(typeof(Action), this, startMethodInfo)
                : DefaultStart;

            _updateMethod = updateMethodInfo != null
                ? (Action)Delegate.CreateDelegate(typeof(Action), this, updateMethodInfo)
                : DefaultUpdate;

            _startMethod.Invoke(); // Invoke start before update is started.

            _updateTimer = new Timer(16); // ~60 FPS (ENGINE LOCKED)
            _updateTimer.Elapsed += OnUpdate;
            _updateTimer.AutoReset = true;
            _updateTimer.Start();
        }

        private void OnUpdate(object sender, ElapsedEventArgs e)
        {
            if (_isRunning)
                _updateMethod.Invoke();
        }

        // BEGIN OVERRIDES
        protected virtual void DefaultStart()
        {
            Console.WriteLine("OctoBehavior: Default Start()");
        }

        protected virtual void DefaultUpdate()
        {
            Console.WriteLine("OctoBehavior: Default Update()");
        }
        // END OVERRIDES

        public void Stop()
        {
            _isRunning = false;
            _updateTimer?.Stop();
        }

        public void StartLoop()
        {
            _isRunning = true;
            _updateTimer?.Start();
        }

        public void Dispose()
        {
            Stop();
            _updateTimer?.Dispose();
        }
    }
}
