using System.Collections;
using Il2CppSLZ.Bonelab;
using Il2CppSLZ.Marrow.Warehouse;
using MelonLoader;
using OctoEngine.MarrowFramework.Internal;
using OctoEngine.MarrowFramework.Internal.Helpers;
using UnityEngine;

// kill me pls, this code is ass
namespace AuroraFramework.TS3Game.Stagecoach
{
    public class StagecoachGiftBox : MonoBehaviour
    {
        public GameObject GiftBox;
        public GameObject SpawnablePlacer;
        public GameObject IdleParent;
        public GameObject GiftPool;
        public GameObject Explosion;
        public GameObject BoxFull;
        public GameObject BoxBits;
        public bool UseSaveSystem;
        public float GiftDelay;

        private SpawnableCrateReference _spawnable;

        private void Start()
        {
            // _spawnComponent = SpawnablePlacer.GetComponent<CrateSpawner>();
            DisablePhys(); // Disable physics so shit doesn't go flying
        }

        public void InitializeGift(SpawnableCrateReference crate)
        {
            _spawnable = crate; // Useless, or is it?
            ModLog.LogMessage("Init Gift");
        }

        public void GiftUnlock()
        {
            DisablePhys();
#if UNITY_EDITOR
            StartCoroutine(GiftUnlockDelay());
#else
            MelonCoroutines.Start(GiftUnlockDelay());
#endif
            ModLog.LogMessage("Unlock Gift");

            Vector3 uselessVector = new Vector3(1, 1, 1);

            SpawnableHelper.SpawnSpawnable(_spawnable, GiftPool, SpawnablePlacer.transform.position, SpawnablePlacer.transform.rotation, uselessVector);

            if (UseSaveSystem)
            {
                SaveGameHelper.WriteValue("StagecoachDeliveredItems", _spawnable.Barcode.ToString());
            }
        }

        public void GiftTravel()
        {
            DisablePhys(); // I don't know why the fuck this is here, but if it isn't, shit breaks
        }

        private void ExplodeOpenGift()
        {
            BoxFull.SetActive(false);
            BoxBits.SetActive(true);
            Explosion.GetComponent<SimpleExplosionForce>();
        }

        private void DisablePhys()
        {
            GiftBox.GetComponent<Rigidbody>().isKinematic = true;
            GiftBox.GetComponent<Rigidbody>().useGravity = false;
            GiftBox.GetComponent<MeshCollider>().enabled = false;
        }

        private void EnablePhys()
        {
            GiftBox.GetComponent<MeshCollider>().enabled = true;
            GiftBox.GetComponent<Rigidbody>().isKinematic = false;
            GiftBox.GetComponent<Rigidbody>().useGravity = true;
        }

        private IEnumerator GiftUnlockDelay()
        {
            yield return new WaitForSeconds(GiftDelay);
            transform.SetParent(IdleParent.transform, worldPositionStays: false);
            transform.localPosition = Vector3.zero; // Reset position = no floating giftboxes
        }

#if MELONLOADER
        public StagecoachGiftBox(IntPtr ptr) : base(ptr) { }
#endif
    }
}