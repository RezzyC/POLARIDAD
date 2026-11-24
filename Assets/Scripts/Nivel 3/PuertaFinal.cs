using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaFinal : MonoBehaviour
{
    public string nombreSiguienteEscena = "Victoria";
    public Palanca[] palancas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MovAmper>() != null)
        {
            for (int i = 0; i < palancas.Length; i++)
            {
                if (!palancas[i].activada)
                {
                    return;
                }
            }

            SceneManager.LoadScene(nombreSiguienteEscena);
        }
    }
}
