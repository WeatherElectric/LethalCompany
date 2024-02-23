using Unity.Netcode;
using UnityEngine;
// ReSharper disable InconsistentNaming

namespace MeetAndHuh.Monobehaviours;

[AddComponentMenu("Weather Electric/Friend Group Stuff/Music Prop")]
public class MusicProp : GrabbableObject
{
    [Space(10f)]
    public AudioClip[] noiseSFX;
    [Space(5f)]
    public AudioSource noiseAudio;
    public AudioSource musicAudio;
    [Space(5f)]
    public float noiseRange;
    public float minLoudness;
    public float maxLoudness;
    public float minPitch;
    public float maxPitch;
    
    private readonly System.Random _noisemakerRandom = new();
    private readonly NetworkVariable<bool> _isPlaying = new(true, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
        
    public override void DiscardItem()
    {
        if (playerHeldBy != null)
        {
            playerHeldBy.equippedUsableItemQE = false;
        }
        isBeingUsed = false;
        base.DiscardItem();
    }
        
    public override void PocketItem()
    {
        if (playerHeldBy != null)
        {
            playerHeldBy.equippedUsableItemQE = false;
        }
        isBeingUsed = false;
        base.PocketItem();
    }
        
    public override void EquipItem()
    {
        base.EquipItem();
        playerHeldBy.equippedUsableItemQE = true;
    }
    
    public override void ItemActivate(bool used, bool buttonDown = true)
    {
        base.ItemActivate(used, buttonDown);
        if (GameNetworkManager.Instance.localPlayerController == null) return;
        PlaySound();
    }

    public override void ItemInteractLeftRight(bool right)
    {
        base.ItemInteractLeftRight(right);
        if (!right)
        {
            if (GameNetworkManager.Instance.localPlayerController == null) return;
            _isPlaying.Value = !_isPlaying.Value;
            musicAudio.mute = !_isPlaying.Value;
        }
    }

    private void PlaySound()
    {
        if (GameNetworkManager.Instance.localPlayerController == null) return;
        int index = _noisemakerRandom.Next(0, noiseSFX.Length);
        float num1 = _noisemakerRandom.Next((int) (minLoudness * 100.0), (int) (maxLoudness * 100.0)) / 100f;
        float num2 = _noisemakerRandom.Next((int) (minPitch * 100.0), (int) (maxPitch * 100.0)) / 100f;
        noiseAudio.pitch = num2;
        noiseAudio.PlayOneShot(noiseSFX[index], num1);
        WalkieTalkie.TransmitOneShotAudio(noiseAudio, noiseSFX[index], num1);
        RoundManager.Instance.PlayAudibleNoise(transform.position, noiseRange, num1, noiseIsInsideClosedShip: isInElevator && StartOfRound.Instance.hangarDoorsClosed);
        if (minLoudness < 0.6000000238418579 || !(playerHeldBy != null))
            return;
        playerHeldBy.timeSinceMakingLoudNoise = 0.0f;
    }
}