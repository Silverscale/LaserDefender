using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected float speed;
    [SerializeField] protected int damage;
    [SerializeField] protected Vector3 fireDirection;
    [SerializeField] protected AudioClip shootingSound;
    [Range(0f, 1f)] [SerializeField] protected float volume = 0.75f;

    virtual public void Fire(Vector3 spawnPos)
    {
        Debug.Log("Trying to fire");
        Projectile projectile = ResourcePool.Get(projectilePrefab).GetComponent<Projectile>();
        if (projectile)
        {
            projectile.SetDamage(damage);
            projectile.SetSpeed(speed);
            projectile.Fire(spawnPos, fireDirection);

            AudioSource.PlayClipAtPoint(shootingSound, new Vector3(0,0,-10), volume);
        }
    }
}
