using UnityEngine;

public class AgarrarObjetos2D : MonoBehaviour
{
    public Transform puntoDeAgarrarDerecha;
    public Transform puntoDeAgarrarIzquierda;
    public float distanciaDeAgarre = 2f;
    public LayerMask capaDeObjeto;

    private GameObject objetoAgarrado = null;
    private bool mirandoDerecha = true;
    private Rigidbody2D rbAmper;

    void Start()
    {
        rbAmper = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rbAmper != null)
        {
            if (rbAmper.linearVelocity.x > 0.1f)
            {
                mirandoDerecha = true;
            }
            else if (rbAmper.linearVelocity.x < -0.1f)
            {
                mirandoDerecha = false;
            }
        }

        if (objetoAgarrado != null)
        {
            Transform puntoActual = null;

            if (mirandoDerecha)
            {
                puntoActual = puntoDeAgarrarDerecha;
            }
            else
            {
                puntoActual = puntoDeAgarrarIzquierda;
            }

            if (puntoActual != null)
            {
                if (objetoAgarrado.transform.parent != puntoActual)
                {
                    objetoAgarrado.transform.SetParent(puntoActual);
                }
                objetoAgarrado.transform.localPosition = Vector3.zero;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && objetoAgarrado == null)
        {
            IntentarAgarrar();
        }

        if (Input.GetKeyDown(KeyCode.Q) && objetoAgarrado != null)
        {
            SoltarObjeto();
        }
    }

    void IntentarAgarrar()
    {
        Collider2D objetoCercano = Physics2D.OverlapCircle(transform.position, distanciaDeAgarre, capaDeObjeto);

        if (objetoCercano != null)
        {
            objetoAgarrado = objetoCercano.gameObject;
            Transform puntoActual = null;
            if (mirandoDerecha)
            {
                puntoActual = puntoDeAgarrarDerecha;
            }
            else
            {
                puntoActual = puntoDeAgarrarIzquierda;
            }

            if (puntoActual != null)
            {
                objetoAgarrado.transform.SetParent(puntoActual);
                objetoAgarrado.transform.localPosition = Vector3.zero;
            }

            SpriteRenderer sr = objetoAgarrado.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.enabled = true;
            }

            Rigidbody2D rb = objetoAgarrado.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.simulated = false; 
            }

            Collider2D col = objetoAgarrado.GetComponent<Collider2D>();
            if (col != null)
            {
                col.enabled = false;
            }
        }
    }

    void SoltarObjeto()
    {
        if (objetoAgarrado != null)
        {
            float direccionMirada = 0f;
            if (mirandoDerecha)
            {
                direccionMirada = 1f;
            }
            else
            {
                direccionMirada = -1f;
            }
        
            objetoAgarrado.transform.SetParent(null);
            objetoAgarrado.transform.position = transform.position + new Vector3(direccionMirada * 1.2f, 0, 0);
            SpriteRenderer sr = objetoAgarrado.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.enabled = true;
            }

            Collider2D col = objetoAgarrado.GetComponent<Collider2D>();
            if (col != null)
            {
                col.enabled = true;
            }

            Rigidbody2D rb = objetoAgarrado.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.simulated = true; 
                rb.linearVelocity = Vector2.zero;
            }

            objetoAgarrado = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaDeAgarre);
    }
}