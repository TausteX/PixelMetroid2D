using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public float velocidadBala = 15f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    public void Disparar()
    {
        if (balaPrefab == null || puntoDisparo == null) return;

        GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);
        
        Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();
        if (rbBala != null)
        {
            rbBala.gravityScale = 0;
            float direccion = transform.localScale.x >= 0 ? 1f : -1f;
            rbBala.linearVelocity = new Vector2(0, velocidadBala);
        }
        
        Destroy(bala, 2f);
    }
}