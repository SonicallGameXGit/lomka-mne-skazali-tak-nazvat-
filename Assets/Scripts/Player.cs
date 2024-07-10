using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private float Speed = 10f;
    private float JumpForce = 7f;
    private uint maxJumps = 2;
    private uint remainingJumps = 2;
    private float jumpReloadTime = 3f;
    private float jumpReloadTimeLeft = 3f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Vector2 Velocity;
        var horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (remainingJumps > 0)
            {
                Velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y + JumpForce);
                remainingJumps -= 1;
                rigidbody.velocity = Velocity;
            }

        }
        else
        {
            Velocity = new Vector2(horizontal * Speed, rigidbody.velocity.y);
            rigidbody.velocity = Velocity;
        }

        if (remainingJumps != maxJumps)
        {
            jumpReloadTimeLeft -= Time.deltaTime;
            if (jumpReloadTimeLeft <= 0)
            {
                jumpReloadTimeLeft = jumpReloadTime;
                remainingJumps = maxJumps;
            }
        }

    }
}
