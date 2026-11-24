using UnityEngine;

public class movingPlataformaUnBoton : MonoBehaviour
{
    public botonPresionado boton;
    public Transform puntoArriba;
    public Transform puntoAbajo;
    public float velocidad = 2f;

    private Transform destino;
    private Rigidbody2D rb;

    void Start()
    {
        destino = puntoArriba;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (boton != null && boton.Presionado)
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