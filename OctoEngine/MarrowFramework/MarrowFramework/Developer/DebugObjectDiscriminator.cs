using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;

namespace OctoEngine.MarrowFramework.Developer
{
    public class DebugObjectDiscriminator : MonoBehaviour
    {
        public GameObject Object;

        private void Start()
        {
            MelonCoroutines.Start(WaitForDataRead());
        }

        private IEnumerator WaitForDataRead()
        {
            yield return new WaitForSeconds(5);
            Object.SetActive(FindObjectOfType<EngineDebug>().ShowDebugObjects);
        }

#if MELONLOADER
        public DebugObjectDiscriminator(IntPtr ptr) : base(ptr) { }
#endif
    }
}
