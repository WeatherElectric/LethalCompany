using Unity.Netcode;
using UnityEngine;

namespace MeetAndHuh.Monobehaviours
{
    [AddComponentMenu("Weather Electric/Friend Group Stuff/Shut Up Mae")]
    public class ShutUpMae : GrabbableObject
    {
        public AudioSource noiseAudio;
        public AudioSource musicAudio;
        public AudioClip[] noiseSfx;
        [Space(3f)]
        public float noiseRange;
        public float maxLoudness;
        public float minLoudness;
        public float minPitch;
        public float maxPitch;
        private System.Random _noisemakerRandom;
        private readonly NetworkVariable<bool> _isPlaying = new(true, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
        
        public override void Start()
        {
            base.Start();
            _noisemakerRandom = new System.Random(StartOfRound.Instance.randomMapSeed + 85);
        }
        
        public override void ItemActivate(bool used, bool buttonDown = true)
        {
            base.ItemActivate(used, buttonDown);
            if (!(GameNetworkManager.Instance.localPlayerController == null))
            {
                int num = _noisemakerRandom.Next(0, noiseSfx.Length);
                float num2 = _noisemakerRandom.Next((int)(minLoudness * 100f), (int)(maxLoudness * 100f)) / 100f;
                float pitch = _noisemakerRandom.Next((int)(minPitch * 100f), (int)(maxPitch * 100f)) / 100f;
                noiseAudio.pitch = pitch;
                noiseAudio.PlayOneShot(noiseSfx[num], num2);
                WalkieTalkie.TransmitOneShotAudio(noiseAudio, noiseSfx[num], num2);
                RoundManager.Instance.PlayAudibleNoise(base.transform.position, noiseRange, num2, 0, isInElevator && StartOfRound.Instance.hangarDoorsClosed);
            }
        }
        
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

        public override void ItemInteractLeftRight(bool right)
        {
            base.ItemInteractLeftRight(right);
            if (!right)
            {
                if (!(GameNetworkManager.Instance.localPlayerController == null))
                {
                    _isPlaying.Value = !_isPlaying.Value;
                    musicAudio.mute = !_isPlaying.Value;
                }
            }
        }
    }
}