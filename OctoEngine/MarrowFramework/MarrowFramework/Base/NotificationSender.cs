using OctoEngine.MarrowFramework.Internal;
using UnityEngine;

namespace OctoEngine.MarrowFramework.Base
{
    public class NotificationSender : MonoBehaviour
    {
        public string Title;
        public string Message;
        public float Duration;

        public void SendInfoNotification()
        {
            NotificationHelper.InfoNotification(Title, Message, Duration);
        }

        public void SendWarningNotification()
        {
            NotificationHelper.WarningNotification(Title, Message, Duration);
        }

        public void SendErrorNotification()
        {
            NotificationHelper.ErrorNotification(Title, Message, Duration);
        }


#if MELONLOADER
        public NotificationSender(IntPtr ptr) : base(ptr) { }
#endif
    }
}
