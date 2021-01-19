using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePad : NetworkBehaviour
{
    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (isLocalPlayer)
        {
            float horizontal = Input.GetAxis("Horizontal");
            transform.position = new Vector3(transform.position.x + horizontal * 0.2f, transform.position.y, 0);
        }
    }
}
