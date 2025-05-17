using Il2CppSLZ.Marrow.Data;
using Il2CppSLZ.Marrow.Warehouse;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace OctoEngine.MarrowFramework.Internal
{
    // Oh wow, something actually useful!
    public class SpawnableHelper
    {
        private static Spawnable spawnable;
        public static void SpawnSpawnable(SpawnableCrateReference crate, GameObject parent, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            GameObject spawnPoint = new GameObject();
            spawnPoint.SetActive(false);  // Prevent Awake from being called immediately

            spawnPoint.transform.parent = parent.transform;
            spawnPoint.transform.position = position;
            spawnPoint.transform.rotation = rotation;
            spawnPoint.transform.localScale = scale;

            CrateSpawner crateSpawner = spawnPoint.AddComponent<CrateSpawner>();
            crateSpawner.spawnableCrateReference = crate;
            crateSpawner.manualMode = false;

            spawnPoint.SetActive(true);
        }
    }
}