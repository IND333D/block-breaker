using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Brick : NetworkBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ball")
        {
            NetworkServer.Destroy(gameObject);
        }
    }
}
