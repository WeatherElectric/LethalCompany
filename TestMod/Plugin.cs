using BepInEx;
using BepInEx.Logging;
using TestMod.Resources;
using UnityEngine;
using WrongLibWithTheWrongTechnique.Modules;

namespace TestMod;

internal static class ModInfo
{
    public const string PLUGIN_GUID = "SoulWithMae.TestMod";
    public const string PLUGIN_NAME = "TestMod";
    public const string PLUGIN_VERSION = "1.0.0";
}

[BepInPlugin(ModInfo.PLUGIN_GUID, ModInfo.PLUGIN_NAME, ModInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource StaticLogger;
    private void Awake()
    {
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        StaticLogger = Logger;
        Assets.Load();
        Hooking.OnPlayerDeath += OnPlayerDeath;
    }
    
    private static void OnPlayerDeath(object sender, PlayerDeathEventArgs e)
    {
        var playerposition = e.Player.transform.position;
        var randint = Random.Range(0, Assets.Screams.Count);
        var sound = Assets.Screams[randint];
        AudioSource.PlayClipAtPoint(sound, playerposition, 1f);
        StaticLogger.LogInfo($"{e.Player.playerUsername} died. Playing sound at {playerposition.ToString()}");
    }
}