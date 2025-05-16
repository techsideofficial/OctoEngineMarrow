using UnityEngine;

namespace OctoEngine.MarrowFramework.Base
{
    public class AreaGates : MonoBehaviour
    {
        public GameObject LeftDoorClosed;
        public GameObject LeftDoorOpen;
        public GameObject RightDoorClosed;
        public GameObject RightDoorOpen;

        public void OpenArea()
        {
            LeftDoorClosed.SetActive(false);
            RightDoorClosed.SetActive(false);
            LeftDoorOpen.SetActive(true);
            RightDoorOpen.SetActive(true);
        }

        public void CloseArea()
        {
            LeftDoorClosed.SetActive(true);
            RightDoorClosed.SetActive(true);
            LeftDoorOpen.SetActive(false);
            RightDoorOpen.SetActive(false);
        }

#if MELONLOADER
        public AreaGates(IntPtr ptr) : base(ptr) { }
#endif
    }
}
