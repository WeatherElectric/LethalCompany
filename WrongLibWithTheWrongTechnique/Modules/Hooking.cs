using System;
using GameNetcodeStuff;
using HarmonyLib;

namespace WrongLibWithTheWrongTechnique.Modules;

/// <summary>
/// Easier hooks to run code at specific times.
/// </summary>
public class Hooking
{
    /// <summary>
    /// Event that is fired when the local player spawns.
    /// </summary>
    public static event OnLocalPlayerSpawn OnLocalPlayerSpawn;
    /// <summary>
    /// Event that is fired when any player dies.
    /// </summary>
    public static event OnAnyPlayerDeath OnAnyPlayerDeath;
    /// <summary>
    /// Event that is fired when the local player dies.
    /// </summary>
    public static event OnLocalPlayerDeath OnLocalPlayerDeath;
    /// <summary>
    /// Event that is fired when any connected player dies.
    /// </summary>
    public static event OnConnectedPlayerDeath OnConnectedPlayerDeath;
    
    internal void onLocalPlayerSpawn(PlayerInfo playerInfo)
    {
        OnLocalPlayerSpawn?.Invoke(this, playerInfo);
    }
    
    internal void onAnyPlayerDeath(PlayerInfo playerInfo)
    {
        OnAnyPlayerDeath?.Invoke(this, playerInfo);
    }
    
    internal void onLocalPlayerDeath(PlayerInfo playerInfo)
    {
        OnLocalPlayerDeath?.Invoke(this, playerInfo);
    }

    internal void onConnectedPlayerDeath(PlayerInfo playerInfo)
    {
        OnConnectedPlayerDeath?.Invoke(this, playerInfo);
    }
}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public delegate void OnLocalPlayerSpawn(object sender, PlayerInfo playerInfo);
public delegate void OnAnyPlayerDeath(object sender, PlayerInfo playerInfo);
public delegate void OnLocalPlayerDeath(object sender, PlayerInfo playerInfo);
public delegate void OnConnectedPlayerDeath(object sender, PlayerInfo playerInfo);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

internal static class HookingPatches
{
    private static readonly Hooking HookingInstance = new();
    
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal static class PlayerDeath
    {
        [HarmonyPostfix]
        [HarmonyPatch("KillPlayer")]
        private static void Postfix(PlayerControllerB __instance)
        {
            if (!__instance.IsLocalPlayer) return;
            HookingInstance.onLocalPlayerDeath(new PlayerInfo(__instance, 
                __instance.causeOfDeath, 
                __instance.health, 
                __instance.playerUsername, 
                __instance.isPlayerAlone, 
                __instance.isPlayerDead));
            HookingInstance.onAnyPlayerDeath(new PlayerInfo(__instance, 
                __instance.causeOfDeath, 
                __instance.health, 
                __instance.playerUsername, 
                __instance.isPlayerAlone, 
                __instance.isPlayerDead));
        }
    }
    
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal static class ConnectedPlayerDeath
    {
        [HarmonyPostfix]
        [HarmonyPatch("KillPlayerServerRpc")]
        private static void Postfix(PlayerControllerB __instance)
        {
            HookingInstance.onConnectedPlayerDeath(new PlayerInfo(__instance, 
                __instance.causeOfDeath, 
                __instance.health, 
                __instance.playerUsername, 
                __instance.isPlayerAlone, 
                __instance.isPlayerDead));
            HookingInstance.onAnyPlayerDeath(new PlayerInfo(__instance, 
                __instance.causeOfDeath, 
                __instance.health, 
                __instance.playerUsername, 
                __instance.isPlayerAlone, 
                __instance.isPlayerDead));
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
            HookingInstance.onLocalPlayerSpawn(new PlayerInfo(__instance, 
                __instance.causeOfDeath, 
                __instance.health, 
                __instance.playerUsername, 
                __instance.isPlayerAlone, 
                __instance.isPlayerDead));
        }
    }
}

/// <summary>
/// Information about a player.
/// </summary>
public class PlayerInfo : EventArgs
{
    /// <summary>
    /// The player controller of the player.
    /// </summary>
    public PlayerControllerB Player { get; }
    /// <summary>
    /// The cause of death of the player.
    /// </summary>
    public CauseOfDeath CauseOfDeath { get; }
    /// <summary>
    /// The health of the player.
    /// </summary>
    public int Health { get; }
    /// <summary>
    /// The username of the player.
    /// </summary>
    public string Username { get; }
    /// <summary>
    /// Whether or not the player is alone.
    /// </summary>
    public bool IsPlayerAlone { get; }
    /// <summary>
    /// Whether or not the player is dead.
    /// </summary>
    public bool IsPlayerDead { get; }

    /// <summary>
    /// Information about a player.
    /// </summary>
    /// <param name="player"></param>
    /// <param name="causeOfDeath"></param>
    /// <param name="health"></param>
    /// <param name="username"></param>
    /// <param name="alone"></param>
    /// <param name="dead"></param>
    public PlayerInfo(PlayerControllerB player, CauseOfDeath causeOfDeath, int health, string username, bool alone, bool dead)
    {
        Player = player;
        CauseOfDeath = causeOfDeath;
        Health = health;
        Username = username;
        IsPlayerAlone = alone;
        IsPlayerDead = dead;
    }
}