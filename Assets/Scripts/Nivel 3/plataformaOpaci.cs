using UnityEngine;

public class plataformaOpaci : MonoBehaviour
{
    public botonPresionado boton;
    public bool empiezaVisible = false;
    public float velocidadFade = 3f;

    private SpriteRenderer sr;
    private Collider2D col;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        Color c = sr.color;
        if (empiezaVisible)
        {
            c.a = 1f;
        }
        else
        {
            c.a = 0f;
        }
        sr.color = c;
        col.enabled = empiezaVisible;
    }

    void Update()
    {
        bool debeSerVisible = empiezaVisible;

        if (boton != null && boton.Presionado)
        {
            debeSerVisible = !empiezaVisible;
        }

        float objetivoAlpha = 0f;
        if (debeSerVisible)
        {
            objetivoAlpha = 1f;
        }

        Color c = sr.color;
        c.a = Mathf.MoveTowards(c.a, objetivoAlpha, velocidadFade * Time.deltaTime);
        sr.color = c;

        if (c.a >= 0.7f)
        {
            col.enabled = true;
        }
        else
        {
            col.enabled = false;
        }
    }
}