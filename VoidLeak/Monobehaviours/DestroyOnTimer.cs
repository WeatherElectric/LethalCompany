using System.Collections;
using Unity.Netcode;
using UnityEngine;

namespace VoidLeak.Monobehaviours;

[AddComponentMenu("Weather Electric/Void Leak/Destroy On Timer")]
public class DestroyOnTimer : NetworkBehaviour
{
    [Tooltip("The object to destroy. If null, the script will destroy whatever object the script is on.")]
    public GameObject objectToDestroy;
    [Space(10f)]
    [Tooltip("The time to destroy the object.")]
    public float timeToDestroy = 10f;
    
    private void Start()
    {
        DestroyServerRpc();
    }
    
    [ServerRpc(RequireOwnership = false)]
    private void DestroyServerRpc()
    {
        DestroyClientRpc();
    }
    
    [ClientRpc]
    private void DestroyClientRpc()
    {
        StartCoroutine(Destroy(objectToDestroy == null ? gameObject : objectToDestroy, timeToDestroy));
    }
    
    private new static IEnumerator Destroy(Object obj, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(obj);
    }
}