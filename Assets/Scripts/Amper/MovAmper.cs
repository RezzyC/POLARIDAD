using UnityEngine;

public class MovAmper : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float jumpForce = 3f;
    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;


    public AudioSource audioSource;
    public AudioClip[] sonidosPasos;
    public float intervaloPasos = 0.4f;
    private float temporizadorPasos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }



        if (isGrounded && moveInput != 0)
        {
            temporizadorPasos += Time.deltaTime;

            if (temporizadorPasos >= intervaloPasos)
            {
                PlayRandomFootstep();
                temporizadorPasos = 0f;
            }
        }
        else
        {
            temporizadorPasos = 0f;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                break;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    void PlayRandomFootstep()
    {
        if (sonidosPasos.Length == 0) return;

        int randomIndex = Random.Range(0, sonidosPasos.Length);

        audioSource.PlayOneShot(sonidosPasos[randomIndex]);
    }

}