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
    /// <summary>
    /// Gets the username of the local player
    /// </summary>
    /// <returns>String of username</returns>
    public static string GetLocalPlayerName()
    {
        var startOfRound = Object.FindObjectOfType<StartOfRound>();
        return startOfRound.localPlayerController.playerUsername;
    }

    /// <summary>
    /// Gets all player usernames.
    /// </summary>
    /// <returns>List of strings of usernames</returns>
    public static List<string> GetAllPlayerNames()
    {
        var startOfRound = Object.FindObjectOfType<StartOfRound>();
        var players = startOfRound.allPlayerScripts;
        List<PlayerControllerB> playerList = players.Where(player => player.isPlayerControlled).ToList();
        return playerList.Select(player => player.playerUsername).ToList();
    }
    
    /// <summary>
    /// Gets all player usernames except the local player.
    /// </summary>
    /// <returns>List of strings of usernames</returns>
    public static List<string> GetConnectedPlayerNames()
    {
        var startOfRound = Object.FindObjectOfType<StartOfRound>();
        var players = startOfRound.OtherClients;
        List<PlayerControllerB> playerList = players.Where(player => player.isPlayerControlled).ToList();
        return playerList.Select(player => player.playerUsername).ToList();
    }
    
    /// <summary>
    /// Gets the local player's player controller.
    /// </summary>
    /// <returns>PlayerControllerB</returns>
    public static PlayerControllerB GetLocalPlayer()
    {
        var startOfRound = Object.FindObjectOfType<StartOfRound>();
        return startOfRound.localPlayerController;
    }
    
    /// <summary>
    /// Gets all connected player controllers.
    /// </summary>
    /// <returns>List of PlayerControllerBs</returns>
    public static List<PlayerControllerB> GetConnectedPlayers()
    {
        var startOfRound = Object.FindObjectOfType<StartOfRound>();
        var players = startOfRound.OtherClients;
        List<PlayerControllerB> playerList = players.Where(player => player.isPlayerControlled).ToList();
        return playerList;
    }
    
    /// <summary>
    /// Gets all player controllers.
    /// </summary>
    /// <returns>List of PlayerControllerB</returns>
    public static List<PlayerControllerB> GetAllPlayers()
    {
        var startOfRound = Object.FindObjectOfType<StartOfRound>();
        var players = startOfRound.allPlayerScripts;
        List<PlayerControllerB> playerList = players.Where(player => player.isPlayerControlled).ToList();
        return playerList;
    }
}