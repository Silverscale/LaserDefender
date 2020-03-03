using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRandom : Weapon
{
    public override void Fire(Vector3 spawnPos)
    {
        fireDirection = (Vector3)Random.insideUnitCircle;
        base.Fire(spawnPos);
    }
}
