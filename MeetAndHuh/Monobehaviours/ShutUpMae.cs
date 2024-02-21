using Unity.Netcode;
using UnityEngine;

namespace MeetAndHuh.Monobehaviours
{
    public class ShutUpMae : GrabbableObject
    {
        public AudioSource audioSource;
        private readonly NetworkVariable<bool> _isPlaying = new(true, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
        
        public override void ItemActivate(bool used, bool buttonDown = true)
        {
            base.ItemActivate(used, buttonDown);
            if (!(GameNetworkManager.Instance.localPlayerController == null))
            {
                _isPlaying.Value = !_isPlaying.Value;
                audioSource.mute = !_isPlaying.Value;
            }
        }
    }
}