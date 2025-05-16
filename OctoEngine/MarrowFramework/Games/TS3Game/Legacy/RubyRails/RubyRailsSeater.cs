using Il2CppSLZ.Marrow;
using UnityEngine;

namespace AuroraFramework.TS3Game.RubyRails
{
    public class RubyRailsSeater : MonoBehaviour
    {
        public Seat RailSeat;

        public void SeatPlayer()
        {
            RailSeat.IngressRig(FindObjectOfType<RigManager>());
        }

        public void EjectPlayer()
        {
            RailSeat.EgressRig(true);
        }

#if MELONLOADER
        public RubyRailsSeater(IntPtr ptr) : base(ptr) { }
#endif
    }
}
