using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] int hitPoints = 10;
    [SerializeField] int scoreValue = 150;
    [SerializeField] bool isBoss = false;

    [Header("Weapon")]
    Weapon myWeapon;
    [SerializeField] float fireCD =  2f;
    [Range(0f, 1f)][SerializeField] float cdRandomness = 0.3f;
    [SerializeField] Vector3 weaponLocation;

    [Header("FXs")]
    [SerializeField] GameObject explosionParticles;
    [SerializeField] AudioClip destroySFX;
    [Range(0f, 1f)] [SerializeField] float volume = 0.75f;


    private int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
        myWeapon = GetComponentInChildren<Weapon>();
        if (myWeapon)
        {
            StartCoroutine(Fire());
        }
    }

    private void Setup()
    {
        currentHP = hitPoints;
    }

    IEnumerator Fire()
    {
        do
        {
            yield return new WaitForSeconds(fireCD * (1 + UnityEngine.Random.Range(-1f, 1f) * cdRandomness));
            myWeapon.Fire(transform.position + weaponLocation);
        } while (true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer other = collision.gameObject.GetComponent<DamageDealer>();
        if (other)
        {
            currentHP -= other.GetDamage();
            other.TargetHit();
            if (currentHP <= 0)
            {
                Destroy();
            }
        }
    }

    private void Destroy()
    {
        //spawn explosion particle effect particle 
        var explosionGO = ResourcePool.Get(explosionParticles);
        explosionGO.transform.position = transform.position;
        explosionGO.SetActive(true);

        //play sfx
        AudioSource.PlayClipAtPoint(destroySFX, Camera.main.transform.position, volume);

        if (isBoss)
        {
            FindObjectOfType<Loader>().LoadGameOver(5f);
        }
        GameSession.AddScore(scoreValue);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Setup();
    }
}
