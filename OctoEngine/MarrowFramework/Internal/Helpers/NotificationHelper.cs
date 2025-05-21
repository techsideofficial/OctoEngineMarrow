using UnityEngine;

namespace OctoEngine.MarrowFramework.Internal.Helpers
{
    // typical messy code from techside
    internal class NotificationHelper
    {
        internal static void InfoNotification(string nTitle, string nMsg, float nLength)
        {
            BoneLib.Notifications.Notification missionCompleteNotif = new BoneLib.Notifications.Notification();
            missionCompleteNotif.Type = BoneLib.Notifications.NotificationType.Information;
            missionCompleteNotif.Title = nTitle;
            missionCompleteNotif.Message = nMsg;
            missionCompleteNotif.PopupLength = nLength;
            missionCompleteNotif.ShowTitleOnPopup = true;
            BoneLib.Notifications.Notifier.Send(missionCompleteNotif);
        }

        internal static void WarningNotification(string nTitle, string nMsg, float nLength)
        {
            BoneLib.Notifications.Notification missionCompleteNotif = new BoneLib.Notifications.Notification();
            missionCompleteNotif.Type = BoneLib.Notifications.NotificationType.Warning;
            missionCompleteNotif.Title = nTitle;
            missionCompleteNotif.Message = nMsg;
            missionCompleteNotif.PopupLength = nLength;
            missionCompleteNotif.ShowTitleOnPopup = true;
            BoneLib.Notifications.Notifier.Send(missionCompleteNotif);
        }

        internal static void ErrorNotification(string nTitle, string nMsg, float nLength)
        {
            BoneLib.Notifications.Notification missionCompleteNotif = new BoneLib.Notifications.Notification();
            missionCompleteNotif.Type = BoneLib.Notifications.NotificationType.Error;
            missionCompleteNotif.Title = nTitle;
            missionCompleteNotif.Message = nMsg;
            missionCompleteNotif.PopupLength = nLength;
            missionCompleteNotif.ShowTitleOnPopup = true;
            BoneLib.Notifications.Notifier.Send(missionCompleteNotif);
        }

        internal static void IconNotification(string nTitle, string nMsg, float nLength, string iconName)
        {
            try
            {
                //var rawData = ContentLoader.GetContentFile("UI", "ICONS\\BONELAB\\" + iconName.ToUpper());
                var rawData = File.ReadAllBytes(Path.Combine(Utils.CommonVars.GameDataDir, "Content", "Textures", iconName));
                Texture2D tex = new Texture2D(2, 2);
                tex.LoadImage(rawData);


                BoneLib.Notifications.Notification missionCompleteNotif = new BoneLib.Notifications.Notification();
                missionCompleteNotif.Type = BoneLib.Notifications.NotificationType.CustomIcon;
                missionCompleteNotif.CustomIcon = tex;
                missionCompleteNotif.Title = nTitle;
                missionCompleteNotif.Message = nMsg;
                missionCompleteNotif.PopupLength = nLength;
                missionCompleteNotif.ShowTitleOnPopup = true;
                BoneLib.Notifications.Notifier.Send(missionCompleteNotif);
            }
            catch
            {
                ModLog.LogError(string.Concat("Icon (", iconName, ") doesn't exist"));
                ErrorNotification("Error", string.Concat("Icon (", iconName, ") doesn't exist"), 5);
            }
        }
    }
}
