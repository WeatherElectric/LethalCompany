using System;
using GameNetcodeStuff;
using HarmonyLib;
using Unity.Netcode;
using UnityEngine.SceneManagement;

namespace StockholmLib.Modules;

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
    /// Event that is fired when any player joins.
    /// </summary>
    public static event OnPlayerJoin OnPlayerJoin;
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
    /// <summary>
    /// Event that is fired when a scene is loaded.
    /// </summary>
    public static event OnSceneLoaded OnSceneLoaded;
    /// <summary>
    /// Event that is fired when a scene is unloaded.
    /// </summary>
    public static event OnSceneUnloaded OnSceneUnloaded;
    
    internal void onLocalPlayerSpawn(PlayerInfo playerInfo)
    {
        OnLocalPlayerSpawn?.Invoke(playerInfo);
    }
    
    internal void onPlayerJoin(PlayerInfo playerInfo)
    {
        OnPlayerJoin?.Invoke(playerInfo);
    }
    
    internal void onAnyPlayerDeath(PlayerInfo playerInfo)
    {
        OnAnyPlayerDeath?.Invoke(playerInfo);
    }
    
    internal void onLocalPlayerDeath(PlayerInfo playerInfo)
    {
        OnLocalPlayerDeath?.Invoke(playerInfo);
    }

    internal void onConnectedPlayerDeath(PlayerInfo playerInfo)
    {
        OnConnectedPlayerDeath?.Invoke(playerInfo);
    }
    
    internal void onSceneLoaded(LevelInfo levelInfo)
    {
        OnSceneLoaded?.Invoke(levelInfo);
    }
    
    internal void onSceneUnloaded(LevelInfo levelInfo)
    {
        OnSceneUnloaded?.Invoke(levelInfo);
    }
}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public delegate void OnLocalPlayerSpawn(PlayerInfo playerInfo);
public delegate void OnPlayerJoin(PlayerInfo playerInfo);
public delegate void OnAnyPlayerDeath(PlayerInfo playerInfo);
public delegate void OnLocalPlayerDeath(PlayerInfo playerInfo);
public delegate void OnConnectedPlayerDeath(PlayerInfo playerInfo);
public delegate void OnSceneLoaded(LevelInfo levelInfo);
public delegate void OnSceneUnloaded(LevelInfo levelInfo);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

internal static class HookingPatches
{
    private static readonly Hooking HookingInstance = new();
    
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal static class PlayerPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Start")]
        private static void PostfixStart(PlayerControllerB __instance)
        {
            if (!__instance.IsLocalPlayer) return;
            HookingInstance.onLocalPlayerSpawn(new PlayerInfo(__instance, 
                __instance.causeOfDeath, 
                __instance.health, 
                __instance.playerUsername, 
                __instance.isPlayerAlone, 
                __instance.isPlayerDead));
        }
        
        [HarmonyPostfix]
        [HarmonyPatch("KillPlayerServerRpc")]
        private static void PostfixRpc(PlayerControllerB __instance)
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
        
        [HarmonyPostfix]
        [HarmonyPatch("KillPlayer")]
        private static void PostfixKill(PlayerControllerB __instance)
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

        [HarmonyPostfix]
        [HarmonyPatch("ConnectClientToPlayerObject")]
        private static void PostfixConnectClient(PlayerControllerB __instance)
        {
            HookingInstance.onPlayerJoin(new PlayerInfo(__instance, 
                __instance.causeOfDeath, 
                __instance.health, 
                __instance.playerUsername, 
                __instance.isPlayerAlone, 
                __instance.isPlayerDead));
        }
    }
    
    [HarmonyPatch(typeof(NetworkSceneManager))]
    public static class ScenePatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("LoadScene")]
        public static void PostfixLoadScene(ref string sceneName)
        {
            HookingInstance.onSceneLoaded(new LevelInfo(sceneName, null, null));
        }
        
        [HarmonyPostfix]
        [HarmonyPatch("UnloadScene")]
        public static void PostfixUnloadScene(ref Scene scene)
        {
            HookingInstance.onSceneUnloaded(new LevelInfo(scene.name, scene.buildIndex, scene.isLoaded));
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

/// <summary>
/// Information about a scene
/// </summary>
public class LevelInfo : EventArgs
{
    public string Name { get; }
    public int? BuildIndex { get; }
    public bool? IsLoaded { get; }
    
    public LevelInfo(string name, int? buildIndex, bool? isLoaded)
    {
        Name = name;
        BuildIndex = buildIndex;
        IsLoaded = isLoaded ?? false;
    }
}