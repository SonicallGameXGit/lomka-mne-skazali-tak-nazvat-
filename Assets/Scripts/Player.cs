using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private float Speed = 10f;
    private float JumpForce = 7f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Vector2 Velocity;
        var horizontal = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Velocity = new Vector2(rigidbody.velocityX, rigidbody.velocityY + JumpForce);
        }
        else
        {
            Velocity = new Vector2(horizontal * Speed, rigidbody.velocityY);
        }

        rigidbody.velocity = Velocity;
    }
}
