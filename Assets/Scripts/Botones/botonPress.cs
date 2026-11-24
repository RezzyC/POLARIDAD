using UnityEngine;

public class botonPress : MonoBehaviour
{
    public bool Presionado = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Caja"))
        {
            Presionado = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Caja"))
        {
            Presionado = false;
        }
    }
}
