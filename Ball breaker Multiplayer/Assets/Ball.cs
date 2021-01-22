using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class Ball : NetworkBehaviour
{
    Vector2 ballvel;
    Vector3 currentvel;
    Rigidbody2D rb;
    [SerializeField] GameObject ballprefab;
    [SerializeField] GameObject bricksobj;
    [SerializeField] Text wintext;

    public override void OnStartServer()
    {
        base.OnStartServer();
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = true;
        ballvel = new Vector2(0, 4);
        rb.velocity = ballvel;
    }

    private void Update()
    {
        // calculating current velocity.
        // speed limit.
        currentvel = rb.velocity;
        if (currentvel.y > 6)
        {
            rb.velocity = new Vector2(currentvel.x, 6);
        }
        if (currentvel.y < -6)
        {
            rb.velocity = new Vector2(currentvel.x, -6);
        }
        if (currentvel.x > 6)
        {
            rb.velocity = new Vector2(6, currentvel.y);
        }
        if (currentvel.y < -6)
        {
            rb.velocity = new Vector2(-6, currentvel.y);
        }

        //Adding force when velocity in a particular direction becomes less or 0.
        // preventing it from momving only vertical or horizontal
        if (rb.velocity.y < 2 && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 3f);
        }
        if (rb.velocity.x < 2 && rb.velocity.x > 0)
        {
            rb.velocity = new Vector2(3f, rb.velocity.x);
        }
        if (rb.velocity.y > -2 && rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, -3f);
        }
        if (rb.velocity.x > -2 && rb.velocity.x < 0)
        {
            rb.velocity = new Vector2(-3f, rb.velocity.x);
        }
    }

    private void Start()
    {
        wintext = GameObject.Find("Text").GetComponent<Text>();
        CmdShoot();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "dead1")
        {
            Debug.Log("dead player 1");
            CmdWin("player 2 win");
        }
        if(collision.collider.tag == "dead2")
        {
            Debug.Log("dead player 2");
            CmdWin("player 1 win");
        }
    }

    [Command]
    void CmdShoot()
    {
        RpcShoot();
    }
    void CmdWin(string text)
    {
        RpcWin(text);
    }

    [ClientRpc]
    void RpcShoot()
    {
        GameObject bricks1 = Instantiate(bricksobj, transform.position + new Vector3(0, 5, 0), Quaternion.identity);
        NetworkServer.Spawn(bricks1);
    }
    void RpcWin(string text)
    {
        wintext.text = text;
        Time.timeScale = 0;
    }
}
