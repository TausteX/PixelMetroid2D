using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float velocidad = 2f;
    public float distanciaPatrulla = 3f;
    private Vector2 puntoInicial;
    private int direccion = 1;

    void Start()
    {
        puntoInicial = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector2.right * velocidad * direccion * Time.deltaTime);

        if (Mathf.Abs(transform.position.x - puntoInicial.x) > distanciaPatrulla)
        {
            direccion *= -1;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Morir();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Puntaje.Instance?.AgregarPuntos(10);
        }
    }
}