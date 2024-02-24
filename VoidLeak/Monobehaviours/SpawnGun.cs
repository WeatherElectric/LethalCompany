﻿using Unity.Netcode;
using UnityEngine;

namespace VoidLeak.Monobehaviours;

[AddComponentMenu("Weather Electric/Void Leak/Spawn Gun")]
public class SpawnGun : GrabbableObject
{
    [Space(30f)]
    public Transform firePoint;
    [Space(10f)]
    public GameObject spawnObject;
    [Space(10f)]
    public float raycastDistance = 10f;
    [Space(10f)]
    public AudioSource spawnAudio;
    [Space(10f)] 
    public GameObject laser;

    public override void ItemActivate(bool used, bool buttonDown = true)
    {
        base.ItemActivate(used, buttonDown);
        if (GameNetworkManager.Instance.localPlayerController == null) return;
        var ray = new Ray(firePoint.position, firePoint.forward);
        if (Physics.Raycast(ray, out var hit, raycastDistance))
        {
            var obj = Instantiate(spawnObject, hit.point, Quaternion.identity);
            Instantiate(obj);
            spawnAudio.Play();
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
        laser.SetActive(false);
    }
        
    public override void PocketItem()
    {
        if (playerHeldBy != null)
        {
            playerHeldBy.equippedUsableItemQE = false;
        }
        isBeingUsed = false;
        base.PocketItem();
        laser.SetActive(false);
    }
        
    public override void EquipItem()
    {
        base.EquipItem();
        playerHeldBy.equippedUsableItemQE = true;
        laser.SetActive(true);
    }
}