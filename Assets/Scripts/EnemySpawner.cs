using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waves;

    void Start()
    {
        StartCoroutine(SpawnAllWaves());
    }

    IEnumerator SpawnAllWaves()
    {
        for (int i = 0; i < waves.Count; i++)
        {
            var currentWave = waves[i];
            yield return StartCoroutine(SpawnWave(currentWave));
            yield return new WaitForSeconds(3f);
        }
    }

    IEnumerator SpawnWave(WaveConfig wave)
    {
        for (int enemyCount = 0; enemyCount < wave.GetNumberOfEnemies(); enemyCount++)
        {
            SpawnEnemy(wave.GetEnemyPrefab(), wave.GetWaypoints());
            yield return new WaitForSeconds(wave.GetTimeBetweenSpawns());
        }
    }

    void SpawnEnemy(GameObject newEnemy, List<Vector3> path)
    {
        EnemyPathing enemy = ResourcePool.Get(newEnemy).GetComponent<EnemyPathing>();
        enemy.SetPath(path);
        enemy.gameObject.SetActive(true);
    }
}
