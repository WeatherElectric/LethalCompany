using UnityEngine;

namespace MeetAndHuh.Monobehaviours
{
    [AddComponentMenu("Weather Electric/Friend Group Stuff/The Evil")]
    public class TheEvil : MusicProp
    {
        [Space(10f)]
        public AudioSource switchMaterialAudio;
        [Space(5f)]
        public Material normalMaterial;
        public Material evilMaterial;
        public MeshRenderer meshRenderer;
        [Space(5f)]
        public ScanNodeProperties scanNodeProperties;
        public string normalText;
        public string evilText;
        
        public override void ItemInteractLeftRight(bool right)
        {
            base.ItemInteractLeftRight(right);
            if (right)
            {
                if (!(GameNetworkManager.Instance.localPlayerController == null))
                {
                    switchMaterialAudio.Play();
                    meshRenderer.material = meshRenderer.material == normalMaterial ? evilMaterial : normalMaterial;
                    scanNodeProperties.headerText = scanNodeProperties.headerText == normalText ? evilText : normalText;
                }
            }
        }
    }
}