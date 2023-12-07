using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using StockholmLib.Modules;

namespace StockholmLib;

/// <summary>
/// The main class of the mod.
/// <see cref="BaseUnityPlugin"/>
/// <see cref="BepInPlugin"/>
/// </summary>
[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
public class Plugin : BaseUnityPlugin
{
    private const string PluginGuid = "SoulWithMae.StockholmLib";
    private const string PluginName = "StockholmLib";
    private const string PluginVersion = "1.0.0";
    
    internal static ManualLogSource StaticLogger;
    private static readonly Harmony Harmony = new(PluginGuid);
    
    private void Awake()
    {
        Logger.LogInfo($"Plugin {PluginGuid} is loaded, version {PluginVersion}.");
        StaticLogger = Logger;
        Harmony.PatchAll();
        Player.Init();
        Hooking.OnSceneLoaded += SceneLoaded;
        Hooking.OnSceneUnloaded += SceneUnloaded;
    }

    private static void SceneLoaded(LevelInfo levelInfo)
    {
        StaticLogger.LogInfo("Scene loaded!");
    }
    
    private static void SceneUnloaded(LevelInfo levelInfo)
    {
        StaticLogger.LogInfo("Scene unloaded!");
    }
}