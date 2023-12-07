using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace BlackMesaInternTransferProgram
{
    internal static class ModInfo
    {
        public const string PluginGuid = "SoulWithMae.BlackMesaInternTransferProgram";
        public const string PluginName = "BlackMesaInternTransferProgram";
        public const string PluginVersion = "1.0.0";
    }
    
    [BepInPlugin(ModInfo.PluginGuid, ModInfo.PluginName, ModInfo.PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource StaticLogger;
        private static readonly Harmony Harmony = new(ModInfo.PluginGuid);

        public static ConfigEntry<float> Volume;
        
        private void Awake()
        {
            Logger.LogInfo($"Plugin {ModInfo.PluginGuid} is loaded as version {ModInfo.PluginVersion}!");
            StaticLogger = Logger;
            Assets.Resources.Load();
            Volume = Config.Bind("General", "Volume", 1f, "The volume of the sounds. Minimum 0, maximum 1.");
            Harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}