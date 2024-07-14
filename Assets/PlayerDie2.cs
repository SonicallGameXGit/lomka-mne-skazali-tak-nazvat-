using UnityEngine;

public class PlayerDie2 : MonoBehaviour
{
    [SerializeField] public GameObject gameOverPanel;
    [SerializeField] public AudioSource dieSound;
    [SerializeField] public AudioSource fireInTheHoleSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Die"))
        {
            gameOverPanel.SetActive(true);
            dieSound.Play();

            Time.timeScale = 0.0f;
        }
        if (collision.CompareTag("fire_in_the_hole"))
        {
            fireInTheHoleSound.Play();
        }
        if (collision.CompareTag("pad"))
        {
            var rb = Player.instance.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 20);
        }
    }
}
