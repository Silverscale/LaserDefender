using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    List<Vector3> waypoints;
    [SerializeField]float moveSpeed = 3f;
    int waypointIndex = 0;

    private void Awake()
    {
        Setup();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPos = waypoints[waypointIndex];
            var deltaMovement = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, deltaMovement);
            if (transform.position == waypoints[waypointIndex])
            {
                waypointIndex++;
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void SetPath(List<Vector3> path)
    {
        waypoints = path;
        transform.position = waypoints[0];
    }

    private void Setup()
    {
        waypointIndex = 0;
    }

    private void OnEnable()
    {
        Setup();
    }
}
