using UnityEngine;

public class movingPlataforma : MonoBehaviour
{
    public botonPresionado[] botones;
    public Transform puntoArriba;
    public Transform puntoAbajo;
    public float velocidad = 2f;

    private Transform destino;
    private bool activada = false;

    void Start()
    {
        destino = puntoArriba;
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

        if (activada)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                destino.position,
                velocidad * Time.deltaTime
            );

            if (Vector2.Distance(transform.position, destino.position) < 0.05f)
            {
                destino = destino == puntoArriba
                    ? puntoAbajo
                    : puntoArriba;
            }
        }
    }
}
