using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private PlayerDie dieService;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Text text; 

    public void GetDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            transform.position = spawnPoint.position;
            text.text = health + ""; 
        }
        else
        {
            dieService.OnDie?.Invoke();
        }
    }
}