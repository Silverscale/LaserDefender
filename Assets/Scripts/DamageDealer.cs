using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    protected int damage = 5;

    virtual public int GetDamage()
    {
        return damage;
    }

    virtual public void TargetHit()
    {
        return;
    }
}

