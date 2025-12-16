using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    Rigidbody2D rb;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        Collider2D thisCol = rb.GetComponent<Collider2D>();

        foreach (var other in FindObjectsOfType<PlayerController>())
        {
            if (other != null)
            {
                Collider2D otherCol = other.GetComponent<Collider2D>();
                Physics2D.IgnoreCollision(thisCol, otherCol);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) return;

        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 targetPos = rb.position + movement * 20f * Time.deltaTime;
        
        float x = Mathf.Clamp(targetPos.x, -6.8f, 6.8f);
        float y = Mathf.Clamp(targetPos.y, -4.3f, 2.6f);

        targetPos = new Vector2(x, y);
        rb.MovePosition(targetPos);
    }
}
