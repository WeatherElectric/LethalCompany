using Unity.Netcode;
using UnityEngine;

namespace MeetAndHuh.Monobehaviours
{
    [AddComponentMenu("Weather Electric/Friend Group Stuff/Shut Up Mae")]
    public class ShutUpMae : NoisemakerProp
    {
        public AudioSource musicAudio;
        [Space(3f)]
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