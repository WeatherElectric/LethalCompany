using BepInEx;

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
        private void Awake()
        {
            Logger.LogInfo($"Plugin {ModInfo.PluginGuid} is loaded, version {ModInfo.PluginVersion}");
            AssetLoader.LoadBundle();
            Logger.LogInfo("Loaded asset bundle. Registering items.");
            AssetLoader.LoadItems();
            Logger.LogInfo("Registered items.");
        }
    }
}