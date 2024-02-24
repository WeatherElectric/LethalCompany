using Unity.Netcode;
using UnityEngine;

namespace VoidLeak.Monobehaviours;

[AddComponentMenu("Weather Electric/Void Leak/Material Variants")]
public class MaterialVariants : NetworkBehaviour
{
    [Tooltip("The item data of the scrap.")]
    public Item itemData;
    [Space(5f)]
    [Tooltip("The mesh renderers to change the material of. This will use the first material in the array.")]
    public MeshRenderer[] meshRenderers;
    
    private readonly NetworkVariable<int> _materialVariant = new(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
    
    private void Start()
    {
        SetRendererServerRpc();
    }

    [ServerRpc(RequireOwnership = false)]
    private void SetRendererServerRpc()
    {
        SetRendererClientRpc();
    }
    
    [ClientRpc]
    private void SetRendererClientRpc()
    {
        if (IsHost)
        {
            _materialVariant.Value = Random.Range(0, itemData.materialVariants.Length);
        }
        foreach (var renderer in meshRenderers)
        {
            renderer.material = itemData.materialVariants[_materialVariant.Value];
        }
    }
}