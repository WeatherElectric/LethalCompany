using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using WrongLibWithTheWrongTechnique.Modules;

namespace WrongLibWithTheWrongTechnique;

/// <summary>
/// The main class of the mod.
/// <see cref="BaseUnityPlugin"/>
/// <see cref="BepInPlugin"/>
/// </summary>
[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
public class Plugin : BaseUnityPlugin
{
    private const string PluginGuid = "SoulWithMae.WrongLibWithTheWrongTechnique";
    private const string PluginName = "WrongLibWithTheWrongTechnique";
    private const string PluginVersion = "1.0.0";
    
    internal static ManualLogSource StaticLogger;
    private static readonly Harmony Harmony = new(PluginGuid);
    
    private void Awake()
    {
        Logger.LogInfo($"Plugin {PluginGuid} is loaded, version {PluginVersion}.");
        StaticLogger = Logger;
        Harmony.PatchAll();
        Hooking.OnLocalPlayerSpawn += OnLocalPlayerSpawn;
        Hooking.OnAnyPlayerDeath += OnAnyPlayerDeath;
    }

    private static void OnLocalPlayerSpawn(object sender, PlayerInfo playerInfo)
    {
        StaticLogger.LogInfo($"Local player name is {playerInfo.Username}");
        StaticLogger.LogInfo($"Local player object is {playerInfo.Player.gameObject}");
        StaticLogger.LogInfo($"Local player has {playerInfo.Health} health");
    }
    
    private static void OnAnyPlayerDeath(object sender, PlayerInfo playerInfo)
    {
        StaticLogger.LogInfo($"{playerInfo.Username} died of {playerInfo.CauseOfDeath.ToString()}.");
    }
}