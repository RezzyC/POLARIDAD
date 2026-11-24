using UnityEngine;

public class botonPresionado : MonoBehaviour
{
    public bool Presionado = false;
    public GameObject[] cajasPermitidas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (EsCajaPermitida(other.gameObject))
        {
            Presionado = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (EsCajaPermitida(other.gameObject))
        {
            Presionado = false;
        }
    }

    private bool EsCajaPermitida(GameObject objeto)
    {
        for (int i = 0; i < cajasPermitidas.Length; i++)
        {
            if (cajasPermitidas[i] == objeto)
            {
                return true;
            }
        }
        return false;
    }
}
