using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CollectibleSpawner : NetworkBehaviour
{
    [SerializeField]
    GameObject crunchiesPrefab;

    public override void OnStartServer()
    {
        InvokeRepeating(nameof(SpawnCrunchies), 5f, 5f);
    }

    void SpawnCrunchies()
    {
        float randomX = Random.Range(-6.35f, 6.35f);
        Vector2 spawnPos = new Vector2(randomX, 7f);

        GameObject obj = Instantiate(crunchiesPrefab, spawnPos, Quaternion.identity);
        NetworkServer.Spawn(obj);
    }
}
