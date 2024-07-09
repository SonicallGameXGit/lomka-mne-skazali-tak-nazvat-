using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cucumber : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float Speed = 10f;
    private float PrevSpeed = 0;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidBody.velocity = new Vector2(Speed, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "border") {
            Speed *= -1;
        }
        else if (collision.gameObject.name == "player" && PrevSpeed != Speed) {
            GetComponent<AudioSource>().Play();
            PrevSpeed = Speed;
        }
    }
}
