using UnityEngine;

public class Bala : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (!collision.CompareTag("Player") && !collision.CompareTag("Bala"))
        {
            Destroy(gameObject);
        }
    }
}