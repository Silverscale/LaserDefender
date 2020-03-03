using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : DamageDealer
{
    float speed;
    float timeToLive;
    bool active = false;

    Rigidbody2D myRB;

    void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
        timeToLive = 2f;
    }

    public bool IsActive()
    {
        return active;
    }

    public void Deactivate()
    {
        active = false;
        transform.position = new Vector3(0, -50, 0);
        gameObject.SetActive(false);
    }

    public void Fire(Vector3 startingPos, Vector3 direction)
    {
        transform.position = startingPos;
        gameObject.SetActive(true);
        myRB.velocity = direction.normalized * speed;
        active = true;
        StartCoroutine(AutoDestroy());
    }

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(timeToLive);
        Deactivate();
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    public override void TargetHit()
    {
        Deactivate();
    }
}
