using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 8f;
    [SerializeField] float xMovementPadding = 0f;
    [SerializeField] float yMovementPadding = 0f;
    [SerializeField] Vector2[] fireLocations;
    [SerializeField] float fireCD;
    [SerializeField] Weapon myWeapon;
    [SerializeField] int hitPoints;
    [SerializeField] AudioClip destroySFX;
    [Range(0f, 1f)] [SerializeField] float volume = 0.75f;


    float xMin, xMax, yMin, yMax;
    int nextFiringPos = 0;

    Coroutine firingCoroutine;
    bool firing = false;
    
    // Start is called before the first frame update
    void Start()
    {
        SetMoveBoundaries();
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetButtonDown("Fire1") && !firing)
        {
            firingCoroutine = StartCoroutine(ContinuousFire());
            firing = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
            firing = false;
        }
    }

    IEnumerator ContinuousFire()
    {
        while (true)
        {
            Fire();
            yield return new WaitForSeconds(fireCD);
        }
    }

    private void Fire()
    {
        myWeapon.Fire(GetFiringLocation());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer other = collision.gameObject.GetComponent<DamageDealer>();
        if (other)
        {
            hitPoints -= other.GetDamage();
            other.TargetHit();
            if (hitPoints <= 0)
            {
                Destroy();
            }
        }
    }

    private void Destroy()
    {
        //play VFX
        //play SFX
        AudioSource.PlayClipAtPoint(destroySFX, Camera.main.transform.position, volume);
        FindObjectOfType<Loader>().LoadGameOver(2f);
        gameObject.SetActive(false);
    }

    public int GetCurrentHP()
    {
        return hitPoints;
    }

    private Vector3 GetFiringLocation()
    {
        nextFiringPos++;
        if (nextFiringPos >= fireLocations.Length)
        {
            nextFiringPos = 0;
        }
        var position = new Vector3(
            transform.position.x + fireLocations[nextFiringPos].x,
            transform.position.y + fireLocations[nextFiringPos].y,
            0f);
        return position;
    }

    private void SetMoveBoundaries()
    {
        Camera gameCamera = FindObjectOfType<Camera>();
        Vector3 botLeft = new Vector3();
        Vector3 topRight = new Vector3();

        botLeft = gameCamera.ViewportToWorldPoint(new Vector3(xMovementPadding, yMovementPadding, 0));
        topRight = gameCamera.ViewportToWorldPoint(new Vector3(1 - xMovementPadding, 1 - yMovementPadding, 0));
        xMin = botLeft.x;
        yMin = botLeft.y;
        xMax = topRight.x;
        yMax = topRight.y;

    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }
}
