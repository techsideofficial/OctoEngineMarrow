using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2CppSLZ.Combat;
using UnityEngine.Events;
using UnityEngine;

namespace OctoEngine.MarrowFramework.Base
{
    public class Timer : MonoBehaviour
    {
        public float Duration;

        public bool IgnoreTimeScale;
        public bool Repeat;
#if UNITY_EDITOR
        [Tooltip("If true, progress event will decrease to 0, rather than increase to 1")]
#endif
        public bool SubtractiveProgress;

        public UnityEventFloat OnTimerStarted;
        public UnityEvent OnTimerFinished;

        private float _timer;


        private void OnEnable()
        {
            this._timer = 0f;
            UnityEventFloat unityEventFloat = this.OnTimerStarted;
            if (unityEventFloat == null)
            {
                return;
            }
            unityEventFloat.Invoke(this.Duration);
        }

        private void Update()
        {
            this._timer += (this.IgnoreTimeScale ? Time.unscaledDeltaTime : Time.deltaTime);
            float num = this._timer / this.Duration;
            if (this.SubtractiveProgress)
            {
                num = 1f - num;
            }
            if (this._timer >= this.Duration)
            {
                if (this.Repeat)
                {
                    this._timer = 0f;
                }
                else
                {
                    base.enabled = false;
                }
                this.OnTimerFinished.Invoke();
            }
        }

        public void SetTimer(float newDur, bool shouldEnable = true)
        {
            this._timer = 0f;
            this.Duration = newDur;
            base.enabled = shouldEnable;
        }
    }
}
