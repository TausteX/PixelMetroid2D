using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    public int puntosRecompensa = 5;
    public AudioClip sonidoRecoger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (sonidoRecoger != null)
            {
                AudioSource.PlayClipAtPoint(sonidoRecoger, transform.position);
            }
            
            if (Puntaje.Instance != null)
            {
                Puntaje.Instance.AgregarPuntos(puntosRecompensa);
            }
            
            Destroy(gameObject);
        }
    }
}