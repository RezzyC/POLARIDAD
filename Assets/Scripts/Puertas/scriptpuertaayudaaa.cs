using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaSalida : MonoBehaviour
{
    public string nombreSiguienteEscena = "Nivel 1";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MovAmper>() != null)
        {
            SceneManager.LoadScene(nombreSiguienteEscena);
        }
    }
}
