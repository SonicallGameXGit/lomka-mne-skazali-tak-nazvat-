using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField]  private int scoreKitkat = 0;
    [SerializeField] private Text scoreText;

    private Rigidbody2D rigidbody;
    private float Speed = 10f;
    private float JumpForce = 7f;
    private uint maxJumps = 2;
    private uint remainingJumps = 2;
    private float jumpReloadTime = 3f;
    private float jumpReloadTimeLeft = 3f;

    private float cooldown = 1.0f;

    public void restart() => cooldown = 1.0f;

    private void Start()
    {
        instance = this;
        AddScore(0);
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void unpauseCucumber()
    {
        GameObject cucumber = GameObject.Find("Cucumber");
        cucumber.GetComponent<Cucumber>().unpause();
    }


    private void Update()
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

    public void AddScore(int score)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            scoreKitkat += score;
            scoreText.text = $"{scoreKitkat}";
        }
    }
}
