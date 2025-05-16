using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;
using MelonLoader;

namespace OctoEngine.MarrowFramework.Developer
{
    public class EngineDebug : MonoBehaviour
    {
        public Material DebugMaterial;
        public bool UseXmlConfig = true;
        public bool VisualizeHitboxes;
        public bool ShowDebugObjects;

        private Xml _debugSettings;

        private void Start()
        {
            _debugSettings = new Xml(Path.Combine(Utils.CommonVars.DataDir, "Config", "SETTINGS", "OCDEBUGSETTINGS.XML"));
            if (UseXmlConfig)
            {
                VisualizeHitboxes = _debugSettings.ReadData("DebugSettings/VisualizeHitboxes") == "1";
                ShowDebugObjects = _debugSettings.ReadData("DebugSettings/ShowDebugObjects") == "1";
            } 
            MelonCoroutines.Start(AsyncTasks()); // Start the task as a coroutine, so it doesn't freeze the game.
        }

        private IEnumerator AsyncTasks()
        {
            if (VisualizeHitboxes)
            {
                List<BoxCollider> colliders = new List<BoxCollider>(FindObjectsOfType<BoxCollider>());

                foreach (BoxCollider collider in colliders)
                {
                    if (collider.isTrigger)
                    {
                        GameObject o = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        o.transform.position = collider.bounds.center;
                        o.transform.rotation = collider.transform.rotation;
                        o.transform.localScale = collider.bounds.size;
                        o.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                        o.GetComponent<MeshRenderer>().material = DebugMaterial;
                        if (o.GetComponents<BoxCollider>().Count > 0)
                        {
                            foreach (BoxCollider c in o.GetComponents<BoxCollider>())
                            {
                                c.isTrigger = true;
                            }
                        }
                    }
                }
            }
            yield return null;
        }

#if MELONLOADER
        public EngineDebug(IntPtr ptr) : base(ptr) { }
#endif
    }
}
