using UnityEngine;

public class movingPlataforma : MonoBehaviour
{
    public botonPresionado[] botones;
    public Transform puntoArriba;
    public Transform puntoAbajo;
    public float velocidad = 2f;

    private Transform destino;
    private bool activada = false;
    private Rigidbody2D rb;

    void Start()
    {
        destino = puntoArriba;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        activada = true;

        foreach (botonPresionado boton in botones)
        {
            if (!boton.Presionado)
            {
                activada = false;
                break;
            }
        }
    }

    void FixedUpdate()
    {
        if (activada)
        {
            Vector2 nuevaPosicion = Vector2.MoveTowards(rb.position, destino.position, velocidad * Time.fixedDeltaTime);
            rb.MovePosition(nuevaPosicion);

            if (Vector2.Distance(rb.position, destino.position) < 0.05f)
            {
                if (destino == puntoArriba)
                {
                    destino = puntoAbajo;
                }
                else
                {
                    destino = puntoArriba;
                }
            }
        }
    }
}
 