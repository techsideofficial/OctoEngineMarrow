using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2CppSLZ.Marrow;
using OctoEngine.MarrowFramework.Base;
using UnityEngine;

namespace OctoEngine.MarrowFramework
{
    public class OctoManager : MonoBehaviour
    {
        private OctoPlayerRig _octoPlayerRig;
        private RigManager _marrowPlayerRig;

        private void Start()
        {
            _octoPlayerRig = FindObjectOfType<OctoPlayerRig>();
            _marrowPlayerRig = FindObjectOfType<RigManager>();

            // Here, we attach the OctoPlayerRig to the BONELAB rig.
            _octoPlayerRig.transform.parent = _marrowPlayerRig.transform;
        }

#if MELONLOADER
        public OctoManager(IntPtr ptr) : base(ptr) { }
#endif
    }
}
