using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace OctoEngine.MarrowFramework.Internal.Helpers
{
    internal class HarmonyPatchHelper
    {
        public static void ApplyPatches(Assembly assembly)
        {
            var harmony = new HarmonyLib.Harmony("com.arparec.octoengine.marrowframework");

            harmony.PatchAll(assembly);
        }
    }
}
