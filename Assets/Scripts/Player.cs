using System.Collections;
using System.Collections.Generic;
using System.Threading;
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

    private float cooldown = 1.0f;

    public void restart()
    {
        cooldown = 1.0f;
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void unpauseCucumber()
    {
        GameObject cucumber = GameObject.Find("Cucumber");
        cucumber.GetComponent<Cucumber>().unpause();
    }


    void Update()
    {
        if(cooldown > 0.0f)
        {
            cooldown -= Time.deltaTime;
            return;
        }

        bool any_input = false;

        Vector2 Velocity;
        var horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            any_input = true;

            if (remainingJumps > 0)
            {
                Velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y + JumpForce);
                remainingJumps -= 1;
                rigidbody.velocity = Velocity;
            }

        }
        else
        {
            if(horizontal > 0.0f) any_input = true;

            Velocity = new Vector2(horizontal * Speed, rigidbody.velocity.y);
            rigidbody.velocity = Velocity;
        }

        if (remainingJumps != maxJumps)
        {
            if (horizontal > 0.0f) any_input = true;

            jumpReloadTimeLeft -= Time.deltaTime;
            if (jumpReloadTimeLeft <= 0)
            {
                jumpReloadTimeLeft = jumpReloadTime;
                remainingJumps = maxJumps;
            }
        }

        if (any_input)
        {
            unpauseCucumber();
        }
    }
}
