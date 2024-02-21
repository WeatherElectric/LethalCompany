using UnityEngine;

namespace MeetAndHuh.Monobehaviours
{
    public class ShutUpMae : GrabbableObject
    {
        public AudioSource audioSource;
        
        public override void ItemActivate(bool used, bool buttonDown = true)
        {
            base.ItemActivate(used, buttonDown);
            if (!(GameNetworkManager.Instance.localPlayerController == null))
            {
                audioSource.mute = !audioSource.mute;
            }
        }
    }
}