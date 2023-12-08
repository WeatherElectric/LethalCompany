using System.Collections.Generic;
using System.Linq;
using GameNetcodeStuff;
using UnityEngine;

namespace StockholmLib.Modules;

/// <summary>
/// Easy access to parts of the player.
/// </summary>
public static class Player
{
    public static PlayerControllerB LocalPlayer { get; private set; }
    public static string LocalPlayerName { get; private set; }
    public static List<PlayerControllerB> ConnectedPlayers { get; private set; }
    public static List<PlayerControllerB> AllPlayers { get; private set; }
    public static List<string> ConnectedPlayerNames { get; private set; }
    public static List<string> AllPlayerNames { get; private set; }

    internal static void Init()
    {
        Hooking.OnLocalPlayerSpawn += OnLocalPlayerSpawn;
        Hooking.OnPlayerJoin += OnPlayerJoin;
        Hooking.OnSceneUnloaded += OnSceneUnloaded;
    }

    private static void OnLocalPlayerSpawn(PlayerInfo playerInfo)
    {
        LocalPlayer = playerInfo.Player;
        LocalPlayerName = playerInfo.Username;
        Plugin.StaticLogger.LogInfo($"Local player ({LocalPlayer.gameObject.name}) spawned! Name: {LocalPlayerName}");
    }
    
    private static void OnPlayerJoin(PlayerInfo playerInfo)
    {
        ConnectedPlayers.Add(playerInfo.Player);
        ConnectedPlayerNames.Add(playerInfo.Username);
        AllPlayers.Add(playerInfo.Player);
        AllPlayerNames.Add(playerInfo.Username);
        Plugin.StaticLogger.LogInfo($"Player ({playerInfo.Player.gameObject.name}) joined! Name: {playerInfo.Username}");
    }

    private static void OnSceneUnloaded(LevelInfo levelInfo)
    {
        LocalPlayer = null;
        LocalPlayerName = null;
        ConnectedPlayers.Clear();
        ConnectedPlayerNames.Clear();
        AllPlayers.Clear();
        AllPlayerNames.Clear();
        Plugin.StaticLogger.LogInfo("Scene unloaded, player data cleared.");
    }
}