using UnityEngine;

public class Palanca : MonoBehaviour
{
    public bool activada = false;
    public Color colorActivada = Color.cyan;

    private SpriteRenderer sr;
    private Animator anim;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!activada && other.GetComponent<MovAmper>() != null)
        {
            activada = true;

            if (sr != null)
            {
                sr.color = colorActivada;
            }

            if (anim != null)
            {
                anim.SetBool("Activada", true);
            }
        }
    }
}