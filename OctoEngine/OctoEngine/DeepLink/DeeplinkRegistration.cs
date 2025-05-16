using Microsoft.Win32;

namespace OctoEngine
{
    public partial class Deeplink
    {
        public static void RegisterDeeplink(string scheme, string appPath)
        {
            try
            {
                using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(scheme))
                {
                    if (key == null) throw new Exception("Failed to create registry key.");

                    key.SetValue("", $"URL:{scheme} Protocol");
                    key.SetValue("URL Protocol", "");

                    using (RegistryKey shellKey = key.CreateSubKey("shell"))
                    using (RegistryKey openKey = shellKey.CreateSubKey("open"))
                    using (RegistryKey commandKey = openKey.CreateSubKey("command"))
                    {
                        commandKey.SetValue("", $"\"{appPath.Replace(".dll", ".exe")}\" \"%1\"");
                    }
                }

                Console.WriteLine($"Protocol '{scheme}' registered successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to register protocol: {ex.Message}");
            }
        }

        public static void UnregisterDeeplink(string protocol)
        {
            try
            {
                Registry.ClassesRoot.DeleteSubKeyTree(protocol);
                Console.WriteLine("Protocol unregistered successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to unregister protocol: {ex.Message}");
            }
        }
    }
}
