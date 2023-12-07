using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GameNetcodeStuff;
using UnityEngine;

namespace WrongLibWithTheWrongTechnique.Modules;

public static class HelperMethods
{
    public static string GetCleanObjectName(string name)
    {
        Regex regex = new Regex(@"\[\d+\]|\(\d+\)"); // Stuff like (1) or [24]
        name = regex.Replace(name, "");
        name = name.Replace("(Clone)", "");
        return name.Trim();
    }
    
    public static string GetLocalPlayerName()
    {
        var startOfRound = Object.FindObjectOfType<StartOfRound>();
        return startOfRound.localPlayerController.playerUsername;
    }

    public static List<string> GetAllPlayerNames()
    {
        var startOfRound = Object.FindObjectOfType<StartOfRound>();
        var players = startOfRound.allPlayerScripts;
        List<PlayerControllerB> playerList = players.Where(player => player.isPlayerControlled).ToList();
        return playerList.Select(player => player.playerUsername).ToList();
    }
    
    public static List<string> GetOtherPlayerNames()
    {
        var startOfRound = Object.FindObjectOfType<StartOfRound>();
        var players = startOfRound.OtherClients;
        List<PlayerControllerB> playerList = players.Where(player => player.isPlayerControlled).ToList();
        return playerList.Select(player => player.playerUsername).ToList();
    }
    
    public static PlayerControllerB GetLocalPlayer()
    {
        var startOfRound = Object.FindObjectOfType<StartOfRound>();
        return startOfRound.localPlayerController;
    }
    
    public static List<PlayerControllerB> GetOtherPlayers()
    {
        var startOfRound = Object.FindObjectOfType<StartOfRound>();
        var players = startOfRound.OtherClients;
        List<PlayerControllerB> playerList = players.Where(player => player.isPlayerControlled).ToList();
        return playerList;
    }
    
    public static List<PlayerControllerB> GetAllPlayers()
    {
        var startOfRound = Object.FindObjectOfType<StartOfRound>();
        var players = startOfRound.allPlayerScripts;
        List<PlayerControllerB> playerList = players.Where(player => player.isPlayerControlled).ToList();
        return playerList;
    }
}