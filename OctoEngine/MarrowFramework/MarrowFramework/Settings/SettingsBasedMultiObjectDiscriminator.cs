using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using MelonLoader;
using OctoEngine.MarrowFramework.Developer;
using UnityEngine;
using System.Collections;

namespace OctoEngine.MarrowFramework.Settings
{
    public class SettingsBasedMultiObjectDiscriminator : MonoBehaviour
    {
        public List<GameObject> Objects;
        public string SettingKey;

        private Xml _xmlData;

        private void Start()
        {
            _xmlData = new(Path.Combine(Utils.CommonVars.DataDir, "Config", "SETTINGS", "OCOBJECTSETTINGS.XML"));
            MelonCoroutines.Start(AsyncTasks());
        }

        private IEnumerator AsyncTasks()
        {
            foreach (GameObject obj in Objects)
            {
                obj.SetActive(_xmlData.ReadData("OptionalEnabledObjects/" + SettingKey) == "1");
            }
            yield return null;
        }

#if MELONLOADER
        public SettingsBasedMultiObjectDiscriminator(IntPtr ptr) : base(ptr) { }
#endif
    }
}
