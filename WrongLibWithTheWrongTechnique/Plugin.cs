using BepInEx;
using BepInEx.Logging;

namespace WrongLibWithTheWrongTechnique;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public static ManualLogSource StaticLogger;
    private void Awake()
    {
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded, version {PluginInfo.PLUGIN_VERSION}.");
        StaticLogger = Logger;
    }
}