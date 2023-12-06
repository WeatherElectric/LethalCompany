using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace AudioLogger;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public static ManualLogSource StaticLogger;
    private readonly Harmony _harmony = new(PluginInfo.PLUGIN_GUID);
    private void Awake()
    {
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        StaticLogger = Logger;
        _harmony.PatchAll(Assembly.GetExecutingAssembly());
    }
}