using UnityEngine;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour
{
    public static Puntaje Instance { get; private set; }
    private int puntos = 0;
    public Text textoPuntaje;
    public GameObject textoGameOver;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        ActualizarUI();
        if (textoGameOver != null)
            textoGameOver.SetActive(false);
    }

    public void AgregarPuntos(int cantidad)
    {
        puntos += cantidad;
        ActualizarUI();
    }

    public int ObtenerPuntos()
    {
        return puntos;
    }

    public void Reiniciar()
    {
        puntos = 0;
        ActualizarUI();
    }

    public void MostrarGameOver()
    {
        if (textoGameOver != null)
            textoGameOver.SetActive(true);
    }

    void ActualizarUI()
    {
        if (textoPuntaje != null)
            textoPuntaje.text = "Puntos: " + puntos;
    }
}