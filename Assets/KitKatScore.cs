using UnityEngine;

public class KitKatScore : MonoBehaviour
{

    [SerializeField] private int _score = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.instance.AddScore(_score);
            Destroy(gameObject);
        }
    }
}
