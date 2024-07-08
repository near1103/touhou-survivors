using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedShard = Instantiate(weaponData.Prefab);
        spawnedShard.transform.position = transform.position; //Assign the position to be the same as this object which is parented to the player
        spawnedShard.GetComponent<ShardBehaviour>().DirectionChecker(pm.lastMovedVector);   //Reference and set the direction
    }
}
