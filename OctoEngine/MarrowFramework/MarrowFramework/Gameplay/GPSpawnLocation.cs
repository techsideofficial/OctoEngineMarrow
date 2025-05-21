using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2CppSLZ.Marrow.Warehouse;
using MelonLoader;
using OctoEngine.MarrowFramework.Internal.Helpers;
using UnityEngine;

namespace OctoEngine.MarrowFramework.Gameplay
{
    public class GPSpawnLocation : MonoBehaviour
    {
        public SpawnableCrateReference Spawnable;
        public bool RespawnOnDestroy;
        public int RespawnTime = 0;

        private bool _isDestroyed = false;

        private void Start()
        {
            SpawnObject();
        }

        public void DestroyObject()
        {
            _isDestroyed = true;
        }

        private void SpawnObject()
        {
            if (_isDestroyed) {
                SpawnableHelper.SpawnSpawnable(
                    Spawnable,
                    this.gameObject.transform.parent.gameObject,
                    this.gameObject.transform.position,
                    this.gameObject.transform.rotation,
                    this.gameObject.transform.localScale
                );
            }
            if (RespawnOnDestroy)
            {
                MelonCoroutines.Start(Respawn());
            }
        }

        private IEnumerator Respawn()
        {
            yield return new WaitForSeconds(RespawnTime);
            SpawnObject();
        }

#if MELONLOADER
        public GPSpawnLocation(IntPtr ptr) : base(ptr) { }
#endif
    }
}
