using UnityEngine;

public class GeneradorPlataformas : MonoBehaviour
{
    public int numeroPlataformas = 10;
    public float distanciaHorizontal = 3f;
    public float alturaSuelo = -2f;
    public float anchoPlataforma = 3f;

    void Start()
    {
        GenerarSuelo();
    }

    void GenerarSuelo()
    {
        for (int i = 0; i < numeroPlataformas; i++)
        {
            GameObject plataforma = new GameObject("Plataforma_" + i);
            plataforma.transform.position = new Vector2(i * distanciaHorizontal, alturaSuelo);

            SpriteRenderer sr = plataforma.AddComponent<SpriteRenderer>();
            sr.sprite = Sprite.Create(Texture2D.whiteTexture, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f));
            sr.color = Color.green;
            sr.size = new Vector2(anchoPlataforma, 0.5f);

            BoxCollider2D col = plataforma.AddComponent<BoxCollider2D>();
            col.size = new Vector2(anchoPlataforma, 0.5f);
        }
    }
}