

using System;
using GameNetcodeStuff;
using HarmonyLib;

namespace WrongLibWithTheWrongTechnique.Modules;

public delegate void OnPlayerDeath(object sender, PlayerDeathEventArgs e);

public class PlayerDeathEventArgs : EventArgs
{
    public PlayerDeathEventArgs(PlayerControllerB player)
    {
        Player = player;
    }

    public PlayerControllerB Player { get; }
}

public delegate void OnLocalPlayerSpawn(object sender, PlayerSpawnEventArgs e);

public class PlayerSpawnEventArgs : EventArgs
{
    public PlayerSpawnEventArgs(PlayerControllerB player)
    {
        Player = player;
    }

    public PlayerControllerB Player { get; }
}

public class Hooking
{
    public static event OnPlayerDeath OnPlayerDeath;
    
    public static event OnLocalPlayerSpawn OnLocalPlayerSpawn;

    internal void onPlayerDeath(PlayerDeathEventArgs e)
    {
        OnPlayerDeath?.Invoke(this, e);
    }
    
    internal void onLocalPlayerSpawn(PlayerSpawnEventArgs e)
    {
        OnLocalPlayerSpawn?.Invoke(this, e);
    }
}

internal static class HookingPatches
{
    private static readonly Hooking HookingInstance = new();
    
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal static class PlayerDeath
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(PlayerControllerB.KillPlayer))]
        private static void Postfix(PlayerControllerB __instance)
        {
            HookingInstance.onPlayerDeath(new PlayerDeathEventArgs(__instance));
        }
    }
    
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal static class PlayerSpawn
    {
        [HarmonyPostfix]
        [HarmonyPatch("Start")]
        private static void Postfix(PlayerControllerB __instance)
        {
            if (!__instance.IsLocalPlayer) return;
            HookingInstance.onLocalPlayerSpawn(new PlayerSpawnEventArgs(__instance));
        }
    }
}