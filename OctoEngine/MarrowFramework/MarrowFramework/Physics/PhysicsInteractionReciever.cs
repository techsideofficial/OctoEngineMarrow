using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2CppSLZ.Marrow.Interaction;
using UnityEngine;

namespace OctoEngine.MarrowFramework.Physics
{
    public class PhysicsInteractionReciever : MonoBehaviour
    {
        public List<string> Tags;
        public float RequiredSpeed;

        public bool IsValidObject(MarrowEntity entity)
        {
            PhysicsInteractionSender triggeringObject = entity.GetComponentInChildren<PhysicsInteractionSender>();
            if (Tags.Count == 0)
            {
                return true;
            }
            foreach (string tag in Tags)
            {
                if (triggeringObject.Tags.Contains(tag))
                {
                    if(triggeringObject.GetSpeed() >= RequiredSpeed)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

#if MELONLOADER
        public PhysicsInteractionReciever(IntPtr ptr) : base(ptr) { }
#endif
    }
}
