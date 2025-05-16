using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;

namespace OctoEngine.MarrowFramework.Physics
{
    public class PhysicsInteractionSender : MonoBehaviour
    {
        public List<string> Tags;
        public Rigidbody PhysicsBody;

        public float GetSpeed()
        {
            return PhysicsBody.velocity.magnitude;
        }

#if MELONLOADER
        public PhysicsInteractionSender(IntPtr ptr) : base(ptr) { }
#endif
    }
}
