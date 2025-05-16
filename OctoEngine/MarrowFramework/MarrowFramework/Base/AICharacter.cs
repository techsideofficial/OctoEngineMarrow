using System.Collections;
using MelonLoader;
using OctoEngine.MarrowFramework.Internal;
using UnityEngine;
using UnityEngine.AI;

namespace OctoEngine.MarrowFramework.Base
{
    public class AICharacter : MonoBehaviour
    {
        public bool IsEnabled = true;
        public List<GameObject> TargetPoints;
        public NavMeshAgent Agent;
#if UNITY_EDITOR
        [Header("AI Settings")]
#endif
        public float ChangeTargetDelay = 5f;
        public float SampleRange = 1f;

        private bool _isActive = false;

        private object _coroutineTokenFieldAILoop;

#if UNITY_EDITOR
        [SerializeField, HideInInspector]
#endif
        public bool IsActive => _isActive;


        private void Start()
        {
            StartAI();
        }

        public void StartAI()
        {

#if UNITY_EDITOR
            _coroutineTokenFieldAILoop = StartCoroutine(AILoop());
#else
            _coroutineTokenFieldAILoop = MelonCoroutines.Start(AILoop());
#endif
        }

        public void StopAI()
        {
            // the StopCoroutine call will need a cast from object to Coroutine
#if UNITY_EDITOR
            StopCoroutine((IEnumerator)_coroutineTokenFieldAILoop);
#else
            MelonCoroutines.Stop(_coroutineTokenFieldAILoop);
#endif
        }

        IEnumerator AILoop()
        {
            while (IsEnabled)
            {
                if (TargetPoints.Count == 0) yield break;

                GameObject poi = GetValidPOI();
                if (poi != null && TryGetNavMeshPosition(poi.transform.position, out Vector3 targetPos))
                {
                    Agent.SetDestination(targetPos);
                }

                yield return new WaitForSeconds(ChangeTargetDelay);
            }
        }

        GameObject GetValidPOI()
        {
            var shuffled = new List<GameObject>(TargetPoints);
            int n = shuffled.Count;
            while (n > 1)
            {
                n--;
                int k = UnityEngine.Random.Range(0, n + 1);
                var temp = shuffled[k];
                shuffled[k] = shuffled[n];
                shuffled[n] = temp;
            }

            foreach (var poi in shuffled)
            {
                if (poi != null && TryGetNavMeshPosition(poi.transform.position, out _))
                    return poi;
            }
            return null;
        }


        bool TryGetNavMeshPosition(Vector3 position, out Vector3 result)
        {
            NavMeshHit hit;
            if (NavMesh.SamplePosition(position, out hit, SampleRange, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
            result = Vector3.zero;
            return false;
        }

#if MELONLOADER
        public AICharacter(IntPtr ptr) : base(ptr) { }
#endif
    }
}