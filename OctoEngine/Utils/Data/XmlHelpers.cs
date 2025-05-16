using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine.Utils
{
    public static class XmlHelpers
    {
        public static Xml SettingsFile() // A helper to return a reference to the default settings file.
        {
            return new Xml(CommonVars.SettingsFilePath);
        }

        public static Xml FlagsFile() // A helper to return a reference to the default settings file.
        {
            return new Xml(Path.Combine(CommonVars.ConfigDir, "FeatureFlags.xml"));
        }
    }
}
