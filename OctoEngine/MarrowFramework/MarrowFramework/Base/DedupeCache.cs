using UnityEngine;

namespace OctoEngine.MarrowFramework.Base
{
    public class DedupeCache : MonoBehaviour
    {
        public List<AudioClip> Clips;
        public List<Mesh> Meshes;
        public List<Material> Materials;
        public List<GameObject> Prefabs;

#if MELONLOADER
        public DedupeCache(IntPtr ptr) : base(ptr) { }
#endif
    }
}