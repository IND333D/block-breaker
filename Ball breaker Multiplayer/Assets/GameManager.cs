using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : NetworkManager
{
    [SerializeField] GameObject ballprefab;
    [SerializeField] GameObject bricksobj;
    public Transform playeronepos;
    public Transform playertwopos;
    GameObject ball1;
    GameObject ball2;
    Vector3 offset = new Vector3(0, 1, 0);

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        Transform position = numPlayers == 0 ? playeronepos : playertwopos;
        GameObject player = Instantiate(playerPrefab, position.position, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player);

        if (numPlayers == 2)
        {
            GameObject bricks1 = Instantiate(bricksobj, playeronepos.position + new Vector3(0, 8, 0), Quaternion.identity);
            NetworkServer.Spawn(bricks1);
            GameObject bricks2 = Instantiate(bricksobj, playertwopos.position + new Vector3(0, 8, 0), Quaternion.identity);
            NetworkServer.Spawn(bricks2);
            ball1 = Instantiate(ballprefab, playeronepos.position + offset, Quaternion.identity);
            NetworkServer.Spawn(ball1);
            ball2 = Instantiate(ballprefab, playertwopos.position + offset, Quaternion.identity);
            NetworkServer.Spawn(ball2);
        }
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        // destroy ball
        if (ball1 != null)
            NetworkServer.Destroy(ball1);

        if (ball2 != null)
            NetworkServer.Destroy(ball2);

        // call base functionality (actually destroys the player)
        base.OnServerDisconnect(conn);
    }
}