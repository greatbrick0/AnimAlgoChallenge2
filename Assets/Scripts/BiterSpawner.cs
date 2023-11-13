using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Worq;

public class BiterSpawner : BiterCollection
{
    [SerializeField]
    GameObject biterObj;
    [SerializeField]
    WaypointRoute route;

    [SerializeField]
    float spawnTime = 5.0f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnBiter), 0.1f, spawnTime);
    }

    private void SpawnBiter()
    {
        collectedBiters.Add(Instantiate(biterObj, transform.parent.parent).GetComponent<Biter>());
        collectedBiters[^1].transform.position = transform.position;
        collectedBiters[^1].GetComponent<AWSPatrol>().group = route;
        collectedBiters[^1].routePoints = route;
    }
}
