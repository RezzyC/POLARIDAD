using UnityEngine;
using UnityEngine.SceneManagement;

public class muerte : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReiniciarEscena();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MovAmper>() != null)
        {
            ReiniciarEscena();
        }
    }

    private void ReiniciarEscena()
    {
        string escenaActual = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(escenaActual);
    }
}