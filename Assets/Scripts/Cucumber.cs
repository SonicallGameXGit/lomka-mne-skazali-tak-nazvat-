using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cucumber : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float Speed = 0.5f;
    private float minSpeedMultipler = 1f;
    private float speedMultipler = 1f;
    private float eventTimer = 1f;

    private bool isPaused = false;

    Vector2 spawnpoint = new Vector2(-10.0f, 0.0f);

    Vector2 start_pos;
    Vector2 target;
    float move_progress;

    GameObject getPlayer()
    {
        return GameObject.Find("player");
    }

    Vector2 getPlayerPosition()
    {
        return getPlayer().GetComponent<Rigidbody2D>().position;
    }

    public void unpause()
    {
        isPaused = false; 
    }

    void updateProgress()
    {
        move_progress = Mathf.Min(move_progress + Time.deltaTime * Speed * speedMultipler, 1.0f);
        if(move_progress >= 1.0f)
        {
            speedMultipler = minSpeedMultipler;
            changeTarget();
            return;
        }

        float mp2 = move_progress * move_progress;
        float mp3 = mp2  * move_progress;

        float a = 3.0f * mp2 - 2.0f * mp3;
        rigidBody.position = (1.0f - a) * start_pos + a * target;
    }

    void changeTarget()
    {
        float random = Random.value;
        start_pos = rigidBody.position;
        move_progress = 0.0f;

        if(random < 0.33f)
        {
            target = getPlayerPosition();
        }
        else if(random < 0.66f)
        {
            float r2 = Random.value;
            Vector2 randomVec2 = new Vector2(Mathf.Sin(r2), Mathf.Cos(r2));
            target = getPlayerPosition() + randomVec2 * 1.0f / (Random.value + 0.1f);
        }
        else
        {
            GameObject player = getPlayer();
            Vector2 velocity = player.GetComponent<Rigidbody2D>().velocity;
            target = getPlayerPosition() + velocity;
        }
    }

    void resetEventTimer()
    {
        eventTimer = minSpeedMultipler + 0.5f;
    }

    public void restart()
    {
        rigidBody.position = spawnpoint;
        isPaused = true;

        resetEventTimer();
        speedMultipler = minSpeedMultipler;
        start_pos = spawnpoint;
        target = spawnpoint;
        move_progress = 0.0f;
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        restart();
    }

    void Update()
    {
        if (isPaused) return;

        eventTimer -= Time.deltaTime;
        if (eventTimer < 0.0f)
        {
            resetEventTimer();

            float random = Random.value;

            if(random < 0.4f)
            {
                changeTarget();
            }
            else if(random < 0.8f)
            {
                speedMultipler += 1.0f;
            }
            else {
                minSpeedMultipler += 0.1f;
                speedMultipler = Mathf.Max(minSpeedMultipler, speedMultipler);
            }
        }

        updateProgress();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isPaused) return;

        if (collision.gameObject.name == "player") {
            GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<PlayerHealth>().GetDamage(1);
        }
    }
}
