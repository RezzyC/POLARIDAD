using UnityEngine;
using UnityEngine.SceneManagement;

public class cambioEscena : MonoBehaviour
{

    public void LoadScene(string Tutorial)
    {
        SceneManager.LoadScene(Tutorial);
    }
}
