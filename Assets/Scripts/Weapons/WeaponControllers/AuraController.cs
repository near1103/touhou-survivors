using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AuraController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedAura = Instantiate(weaponData.Prefab);
        spawnedAura.transform.position = transform.position; //Assign the position to be the same as this object which is parented to the player
        spawnedAura.transform.parent = transform;
    }
}
