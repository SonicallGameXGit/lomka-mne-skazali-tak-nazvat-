using UnityEngine;

public class PlayerDie2 : MonoBehaviour
{
    [SerializeField] public GameObject gameOverPanel;
    [SerializeField] public AudioSource dieSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Die"))
        {
            gameOverPanel.SetActive(true);
            dieSound.Play();

            Time.timeScale = 0.0f;
        }
    }
}
