using UnityEngine;

public class PlayerCameraFollower : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float followSpeed;

    private void Start()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>().gameObject;
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, followSpeed * Time.fixedDeltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10.0f);
    }
}
