using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using OctoEngine.Formats;
using OctoEngine.Utils;


namespace OctoEngine.PluginAPI
{
    public class PluginManager
    {
        private readonly Dictionary<string, PluginManifest> _pluginManifests = new();

        public void LoadPluginManifests(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException($"The directory '{directoryPath}' does not exist.");
            }

            foreach (var dir in Directory.GetDirectories(directoryPath))
            {
                var manifestPath = Path.Combine(dir, "manifest.json");
                if (File.Exists(manifestPath))
                {
                    var manifestContent = File.ReadAllText(manifestPath);
                    var pluginManifest = JsonConvert.DeserializeObject<PluginManifest>(manifestContent);
                    if (pluginManifest != null)
                    {
                        _pluginManifests[pluginManifest.ID] = pluginManifest;
                        Logging.LogMessage($"Loaded plugin '{pluginManifest.Name}'");
                    }
                }
            }
        }

        public PluginManifest GetPluginManifest(string pluginId)
        {
            _pluginManifests.TryGetValue(pluginId, out var pluginManifest);
            return pluginManifest;
        }

        public IEnumerable<PluginManifest> GetAllPluginManifests()
        {
            return _pluginManifests.Values;
        }
    }

}