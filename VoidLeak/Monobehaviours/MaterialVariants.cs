using System;
using Unity.Netcode;
using UnityEngine;

namespace VoidLeak.Monobehaviours;

[AddComponentMenu("Weather Electric/Void Leak/Material Variants")]
public class MaterialVariants : NetworkBehaviour
{
    [Tooltip("The item data of the scrap.")]
    public Item itemData;
    [Space(5f)]
    [Tooltip("The mesh renderers to change the material of.")]
    public VariantRenderers[] meshRenderers;
    
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
        int variant = UnityEngine.Random.Range(0, itemData.materialVariants.Length);
        foreach (var renderer in meshRenderers)
        {
            renderer.meshRenderer.materials[renderer.materialIndex] = itemData.materialVariants[variant];
        }
    }
}

[Serializable]
public class VariantRenderers
{
    [Tooltip("The mesh renderer to change the material of.")]
    public MeshRenderer meshRenderer;
    [Space(5f)]
    [Tooltip("The index of the material to change.")]
    public int materialIndex;
}