using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 10f;
    private Rigidbody2D rb;
    private bool enSuelo = true;
    private bool movimientoActivo = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!movimientoActivo) return;

        float movimientoX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(movimientoX * velocidad, rb.linearVelocity.y);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            Saltar();
        }
    }

    public void Saltar()
    {
        if (enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            enSuelo = false;
        }
    }

    public void MoverDerecha()
    {
        if (movimientoActivo)
            rb.linearVelocity = new Vector2(velocidad, rb.linearVelocity.y);
    }

    public void MoverIzquierda()
    {
        if (movimientoActivo)
            rb.linearVelocity = new Vector2(-velocidad, rb.linearVelocity.y);
    }

    public void DetenerMovimiento()
    {
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo") || collision.gameObject.CompareTag("Plataforma") || collision.gameObject.CompareTag("Untagged"))
        {
            enSuelo = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        enSuelo = true;
    }

    public void Morir()
    {
        movimientoActivo = false;
        rb.linearVelocity = Vector2.zero;
        rb.isKinematic = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        Puntaje.Instance?.MostrarGameOver();
    }

    public void RecargarEscena()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}