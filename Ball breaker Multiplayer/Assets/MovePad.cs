using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePad : NetworkBehaviour
{
    [SerializeField] GameObject ballprefab;

    private void FixedUpdate()
    {
        MovePlayer();
    }


    void MovePlayer()
    {

        int playersconnected = NetworkServer.connections.Count;
        if (isLocalPlayer)
        {
            Debug.Log(playersconnected);
            float horizontal = Input.GetAxis("Horizontal");
            Vector3 move = new Vector3(horizontal, 0, 0);
            transform.position = transform.position + move * 0.2f;
        }

    }
}
