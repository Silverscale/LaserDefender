using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Cluster Wave Config")]
public class ClusterWave : WaveConfig
{
    [SerializeField] float ClusterRange = 1f;
    public override List<Vector3> GetWaypoints()
    {
        var waypoints = base.GetWaypoints();
        Randomize(waypoints);
        return waypoints;
    }

    private void Randomize(List<Vector3> waypoints)
    {
        for (int i = 0; i < waypoints.Count; i++)
        {
            Vector3 offset = new Vector3(Random.Range(-1f, 1f) , Random.Range(-1f, 1f), 0f).normalized * ClusterRange;
            waypoints[i] += offset;
        }
    }
}
