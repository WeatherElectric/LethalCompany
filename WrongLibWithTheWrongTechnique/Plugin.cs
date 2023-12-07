using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using WrongLibWithTheWrongTechnique.Modules;

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
        Hooking.OnLocalPlayerSpawn += OnLocalPlayerSpawn;
        Hooking.OnPlayerDeath += OnPlayerDeath;
    }

    private static void OnLocalPlayerSpawn(object sender, PlayerSpawnEventArgs e)
    {
        StaticLogger.LogInfo($"Local player name is {e.Player.playerUsername}");
        StaticLogger.LogInfo($"Local player object is {e.Player.name}");
        StaticLogger.LogInfo($"Local player has {e.Player.health} health");
    }
    
    private static void OnPlayerDeath(object sender, PlayerDeathEventArgs e)
    {
        StaticLogger.LogInfo($"{e.Player.playerUsername} died.");
    }
}