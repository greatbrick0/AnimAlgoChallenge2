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

    void Start()
    {
        InvokeRepeating(nameof(SpawnBiter), 1, 5);
    }

    private void SpawnBiter()
    {
        collectedBiters.Add(Instantiate(biterObj, transform.parent.parent).GetComponent<Biter>());
        collectedBiters[^1].transform.position = transform.position;
        collectedBiters[^1].GetComponent<AWSPatrol>().group = route;
    }
}
