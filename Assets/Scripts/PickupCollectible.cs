using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PickupCollectible : NetworkBehaviour
{
    private bool hasFallen = false;
    float targetYPos;

    private void Start()
    {
        targetYPos = Random.Range(2.25f, -4.35f);
    }

    void Update()
    {
        if (hasFallen) return;

        transform.position += Vector3.down * 5f * Time.deltaTime;

        if (transform.position.y <= targetYPos)
        {
            transform.position = new Vector3(transform.position.x, targetYPos, transform.position.z);
            hasFallen = true;
        }
    }

    [ServerCallback]
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        NetworkServer.Destroy(gameObject);
    }
}
