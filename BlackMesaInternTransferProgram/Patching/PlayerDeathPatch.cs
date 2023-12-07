using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;

namespace BlackMesaInternTransferProgram.Patching;

internal static class PlayerDeathPatch
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal static class LocalPlayerDeath
    {
        [HarmonyPostfix]
        [HarmonyPatch("KillPlayer")]
        private static void Postfix(PlayerControllerB __instance)
        {
            OnPlayerDeath(__instance.playerUsername, __instance.causeOfDeath, __instance.transform.position);
        }
    }
    
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal static class ServerPlayerDeath
    {
        [HarmonyPostfix]
        [HarmonyPatch("KillPlayerServerRpc")]
        private static void Postfix(PlayerControllerB __instance)
        {
            OnPlayerDeath(__instance.playerUsername, __instance.causeOfDeath, __instance.transform.position);
        }
    }
    
    private static void OnPlayerDeath(string username, CauseOfDeath causeOfDeath, Vector3 position)
    {
        switch (causeOfDeath)
        {
            case CauseOfDeath.Unknown:
                UnknownDeath(username, position);
                break;
            case CauseOfDeath.Bludgeoning:
                BludgeoningDeath(username, position);
                break;
            case CauseOfDeath.Gravity:
                GravityDeath(username, position);
                break;
            case CauseOfDeath.Blast:
                BlastDeath(username, position);
                break;
            case CauseOfDeath.Strangulation:
                StrangulationDeath(username, position);
                break;
            case CauseOfDeath.Suffocation:
                SuffocationDeath(username, position);
                break;
            case CauseOfDeath.Mauling:
                MaulingDeath(username, position);
                break;
            case CauseOfDeath.Gunshots:
                GunshotsDeath(username, position);
                break;
            case CauseOfDeath.Crushing:
                CrushingDeath(username, position);
                break;
            case CauseOfDeath.Drowning:
                DrowningDeath(username, position);
                break;
            case CauseOfDeath.Abandoned:
                AbandonedDeath(username, position);
                break;
            case CauseOfDeath.Electrocution:
                ElectrocutionDeath(username, position);
                break;
            default:
                UnknownDeath(username, position);
                Plugin.StaticLogger.LogError($"Death type was wrong. Playing unknown sound at {position.ToString()}");
                break;
        }
    }
    
    private static void UnknownDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Assets.Resources.Unknown.Count);
        var sound = Assets.Resources.Unknown[randint];
        AudioSource.PlayClipAtPoint(sound, position, Plugin.Volume.Value);
        Plugin.StaticLogger.LogInfo($"{username} died to unknown. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void BludgeoningDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Assets.Resources.Bludgeoning.Count);
        var sound = Assets.Resources.Bludgeoning[randint];
        AudioSource.PlayClipAtPoint(sound, position, Plugin.Volume.Value);
        Plugin.StaticLogger.LogInfo($"{username} died to bludgeoning. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void GravityDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Assets.Resources.Gravity.Count);
        var sound = Assets.Resources.Gravity[randint];
        AudioSource.PlayClipAtPoint(sound, position, Plugin.Volume.Value);
        Plugin.StaticLogger.LogInfo($"{username} died to gravity. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void BlastDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Assets.Resources.Blast.Count);
        var sound = Assets.Resources.Blast[randint];
        AudioSource.PlayClipAtPoint(sound, position, Plugin.Volume.Value);
        Plugin.StaticLogger.LogInfo($"{username} died to blast. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void StrangulationDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Assets.Resources.Strangulation.Count);
        var sound = Assets.Resources.Strangulation[randint];
        AudioSource.PlayClipAtPoint(sound, position, Plugin.Volume.Value);
        Plugin.StaticLogger.LogInfo($"{username} died to strangulation. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void SuffocationDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Assets.Resources.Suffocation.Count);
        var sound = Assets.Resources.Suffocation[randint];
        AudioSource.PlayClipAtPoint(sound, position, Plugin.Volume.Value);
        Plugin.StaticLogger.LogInfo($"{username} died to suffocation. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void MaulingDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Assets.Resources.Mauling.Count);
        var sound = Assets.Resources.Mauling[randint];
        AudioSource.PlayClipAtPoint(sound, position, Plugin.Volume.Value);
        Plugin.StaticLogger.LogInfo($"{username} died to mauling. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void GunshotsDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Assets.Resources.Gunshots.Count);
        var sound = Assets.Resources.Gunshots[randint];
        AudioSource.PlayClipAtPoint(sound, position, Plugin.Volume.Value);
        Plugin.StaticLogger.LogInfo($"{username} died to gunshots. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void CrushingDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Assets.Resources.Crushing.Count);
        var sound = Assets.Resources.Crushing[randint];
        AudioSource.PlayClipAtPoint(sound, position, Plugin.Volume.Value);
        Plugin.StaticLogger.LogInfo($"{username} died to crushing. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void DrowningDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Assets.Resources.Drowning.Count);
        var sound = Assets.Resources.Drowning[randint];
        AudioSource.PlayClipAtPoint(sound, position, Plugin.Volume.Value);
        Plugin.StaticLogger.LogInfo($"{username} died to drowning. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void AbandonedDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Assets.Resources.Abandoned.Count);
        var sound = Assets.Resources.Abandoned[randint];
        AudioSource.PlayClipAtPoint(sound, position, Plugin.Volume.Value);
        Plugin.StaticLogger.LogInfo($"{username} died to abandoned. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void ElectrocutionDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Assets.Resources.Electrocution.Count);
        var sound = Assets.Resources.Electrocution[randint];
        AudioSource.PlayClipAtPoint(sound, position, Plugin.Volume.Value);
        Plugin.StaticLogger.LogInfo($"{username} died to electrocution. Playing {sound.name} at {position.ToString()}");
    }
}