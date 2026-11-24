using UnityEngine;

public class Movingplat2 : MonoBehaviour
{
    public botonPress[] botones;
    public Transform puntoArriba;
    public Transform puntoAbajo;
    public float velocidad = 2f;

    private Transform destino;
    private Rigidbody2D rb;
    private bool activada = false;

    void Start()
    {
        destino = puntoArriba;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        activada = true;
        foreach (botonPress boton in botones)
        {
            if (boton == null || !boton.Presionado)
            {
                activada = false;
                break;
            }
        }

        if (activada)
        {
            Vector2 nuevaPosicion = Vector2.MoveTowards(rb.position, destino.position, velocidad * Time.fixedDeltaTime);
            rb.MovePosition(nuevaPosicion);

            if (Vector2.Distance(rb.position, destino.position) < 0.05f)
            {
                destino = destino == puntoArriba ? puntoAbajo : puntoArriba;
            }
        }
    }
}
