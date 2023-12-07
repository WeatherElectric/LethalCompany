

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

public class Hooking
{
    public event OnPlayerDeath OnPlayerDeath;

    internal void onPlayerDeath(PlayerDeathEventArgs e)
    {
        OnPlayerDeath?.Invoke(this, e);
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
}