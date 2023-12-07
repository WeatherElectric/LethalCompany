using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GameNetcodeStuff;
using UnityEngine;

namespace StockholmLib.Modules;

/// <summary>
/// Helper methods of various kinds.
/// </summary>
public static class HelperMethods
{
    /// <summary>
    /// Gets the name of the object without the (Clone) or [24] at the end.
    /// </summary>
    /// <param name="name"></param>
    /// <returns>String of clean name</returns>
    public static string GetCleanObjectName(string name)
    {
        Regex regex = new Regex(@"\[\d+\]|\(\d+\)");
        name = regex.Replace(name, "");
        name = name.Replace("(Clone)", "");
        return name.Trim();
    }
    
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