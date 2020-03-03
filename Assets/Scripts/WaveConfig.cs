using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] protected GameObject enemyPrefab; 
    [SerializeField] protected GameObject pathPrefab;
    [SerializeField] protected float timeBetweenSpawns = 0.5f;
    [SerializeField] protected float spawnRandomFactor = 0.3f;
    [SerializeField] protected int numberOfEnemies = 5;
    //[SerializeField] float moveSpeed = 5f;


    
    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public GameObject GetPathPrefab()
    {
        return pathPrefab;
    }

    public virtual List<Vector3> GetWaypoints()
    {
        var waypoints = new List<Vector3>();
        foreach (Transform child in pathPrefab.transform)
        {
            waypoints.Add(child.position);
        }
        return waypoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }
}
