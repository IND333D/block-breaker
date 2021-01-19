using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 ballvel;
    Vector3 currentvel;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballvel = new Vector2(4, -4);
        rb.velocity = ballvel;
    }

    private void Update()
    {
        // calculating current velocity.
        // speed limit.
        currentvel = rb.velocity;
        if(currentvel.y > 6)
        {
            rb.velocity = new Vector2(currentvel.x, 6);
        }
        if (currentvel.y < -6)
        {
            rb.velocity = new Vector2(currentvel.x, -6);
        }
        if (currentvel.x > 6)
        {
            rb.velocity = new Vector2(6,currentvel.y);
        }
        if (currentvel.y < -6)
        {
            rb.velocity = new Vector2(-6, currentvel.y);
        }

        //Adding force when velocity in a particular direction becomes less or 0.
        // preventing it from momving only vertical or horizontal
        if (rb.velocity.y < 2 && rb.velocity.y > -2)
        {
            rb.velocity = new Vector2(rb.velocity.x, 3f);
        }
        if (rb.velocity.x < 2 && rb.velocity.x > -2)
        {
            rb.velocity = new Vector2(3f, rb.velocity.x);
        }
    }
}
