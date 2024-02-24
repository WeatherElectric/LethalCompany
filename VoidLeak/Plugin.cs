using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using UnityEngine;

namespace VoidLeak
{
    public class ModInfo
    {
        public const string PluginGuid = "SoulWithMae.VoidLeak";
        public const string PluginName = "VoidLeak";
        public const string PluginVersion = "1.0.0";
    }
    
    [BepInPlugin(ModInfo.PluginGuid, ModInfo.PluginName, ModInfo.PluginVersion)]
    [BepInDependency(LethalLib.Plugin.ModGUID)]
    public class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource mls;
        private void Awake()
        {
            mls = Logger;
            
            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                foreach (var method in methods)
                {
                    var attributes = method.GetCustomAttributes(typeof(RuntimeInitializeOnLoadMethodAttribute), false);
                    if (attributes.Length > 0)
                    {
                        method.Invoke(null, null);
                    }
                }
            }
            
            Logger.LogInfo($"Plugin {ModInfo.PluginGuid} is loaded, version {ModInfo.PluginVersion}");
            AssetLoader.LoadBundle();
            Logger.LogInfo("Loaded asset bundle. Registering items.");
            AssetLoader.LoadItems();
            Logger.LogInfo("Registered items.");
        }
    }
}