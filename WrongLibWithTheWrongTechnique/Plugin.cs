using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace WrongLibWithTheWrongTechnique;

internal static class ModInfo
{
    public const string PluginGuid = "SoulWithMae.WrongLibWithTheWrongTechnique";
    public const string PluginName = "WrongLibWithTheWrongTechnique";
    public const string PluginVersion = "1.0.0";
}

[BepInPlugin(ModInfo.PluginGuid, ModInfo.PluginName, ModInfo.PluginVersion)]
public class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource StaticLogger;
    internal static readonly Harmony Harmony = new(ModInfo.PluginGuid);
    private void Awake()
    {
        Logger.LogInfo($"Plugin {ModInfo.PluginGuid} is loaded, version {ModInfo.PluginVersion}.");
        StaticLogger = Logger;
        Harmony.PatchAll();
    }
}