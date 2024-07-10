using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cucumber : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float Speed = 10f;
    private float PrevSpeed = 0;
    private float speedMultipler = 1f;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        speedMultipler += Time.deltaTime * 0.05f;

        rigidBody.velocity = new Vector2(Speed*speedMultipler, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ПОФИКСИТЕ КОЛЛАЙДЕРЫ НЕ РАБОТАЮТ
        // НЕ ИГРАБЕЛЬНО

        if (collision.gameObject.name == "border") {
            Speed *= -1;
        }
        else if (collision.gameObject.name == "player" && PrevSpeed != Speed) {
            GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<PlayerHealth>().GetDamage(1);
            PrevSpeed = Speed;
        }
    }
}
