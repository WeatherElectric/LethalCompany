using StockholmLib.Modules;
using UnityEngine;

namespace BlackMesaInternTransferProgram;

internal static class PlayerDeathManager
{
    public static void Init()
    {
        Hooking.OnAnyPlayerDeath += OnPlayerDeath;
    }
    
    private static void OnPlayerDeath(object sender, PlayerInfo playerInfo)
    {
        var username = playerInfo.Username;
        var position = playerInfo.Player.transform.position;
        var causeOfDeath = playerInfo.CauseOfDeath;
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

    private static void PlayAudio(AudioClip sound, Vector3 position)
    {
        if (Plugin.AlertEnemies.Value)
        {
            RoundManager.Instance.PlayAudibleNoise(position, Plugin.NoiseRange.Value, Plugin.NoiseLoudness.Value);
            AudioSource.PlayClipAtPoint(sound, position, Plugin.Volume.Value);
        }
        else
        {
            AudioSource.PlayClipAtPoint(sound, position, Plugin.Volume.Value);
        }
    }
    
    private static void UnknownDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Resources.Unknown.Count);
        var sound = Resources.Unknown[randint];
        PlayAudio(sound, position);
        Plugin.StaticLogger.LogInfo($"{username} died to unknown. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void BludgeoningDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Resources.Bludgeoning.Count);
        var sound = Resources.Bludgeoning[randint];
        PlayAudio(sound, position);
        Plugin.StaticLogger.LogInfo($"{username} died to bludgeoning. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void GravityDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Resources.Gravity.Count);
        var sound = Resources.Gravity[randint];
        PlayAudio(sound, position);
        Plugin.StaticLogger.LogInfo($"{username} died to gravity. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void BlastDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Resources.Blast.Count);
        var sound = Resources.Blast[randint];
        PlayAudio(sound, position);
        Plugin.StaticLogger.LogInfo($"{username} died to blast. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void StrangulationDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Resources.Strangulation.Count);
        var sound = Resources.Strangulation[randint];
        PlayAudio(sound, position);
        Plugin.StaticLogger.LogInfo($"{username} died to strangulation. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void SuffocationDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Resources.Suffocation.Count);
        var sound = Resources.Suffocation[randint];
        PlayAudio(sound, position);
        Plugin.StaticLogger.LogInfo($"{username} died to suffocation. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void MaulingDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Resources.Mauling.Count);
        var sound = Resources.Mauling[randint];
        PlayAudio(sound, position);
        Plugin.StaticLogger.LogInfo($"{username} died to mauling. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void GunshotsDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Resources.Gunshots.Count);
        var sound = Resources.Gunshots[randint];
        PlayAudio(sound, position);
        Plugin.StaticLogger.LogInfo($"{username} died to gunshots. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void CrushingDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Resources.Crushing.Count);
        var sound = Resources.Crushing[randint];
        PlayAudio(sound, position);
        Plugin.StaticLogger.LogInfo($"{username} died to crushing. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void DrowningDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Resources.Drowning.Count);
        var sound = Resources.Drowning[randint];
        PlayAudio(sound, position);
        Plugin.StaticLogger.LogInfo($"{username} died to drowning. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void AbandonedDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Resources.Abandoned.Count);
        var sound = Resources.Abandoned[randint];
        PlayAudio(sound, position);
        Plugin.StaticLogger.LogInfo($"{username} died to abandoned. Playing {sound.name} at {position.ToString()}");
    }
    
    private static void ElectrocutionDeath(string username, Vector3 position)
    {
        var randint = Random.Range(0, Resources.Electrocution.Count);
        var sound = Resources.Electrocution[randint];
        PlayAudio(sound, position);
        Plugin.StaticLogger.LogInfo($"{username} died to electrocution. Playing {sound.name} at {position.ToString()}");
    }
}