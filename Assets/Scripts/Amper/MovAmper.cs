using UnityEngine;

public class MovAmper : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private float distanciaSuelo = 0.2f;
    [SerializeField] private LayerMask capaSuelo;

    private Rigidbody2D rb;
    private Collider2D col;
    private float moveInput;
    private bool isGrounded;

    public AudioSource audioSource;
    public AudioClip[] sonidosPasos;
    public float intervaloPasos = 0.4f;
    private float temporizadorPasos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        Vector2 origenRayo = new Vector2(col.bounds.center.x, col.bounds.min.y - 0.02f);
        RaycastHit2D hit = Physics2D.Raycast(origenRayo, Vector2.down, distanciaSuelo, capaSuelo);

        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

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

    void PlayRandomFootstep()
    {
        if (sonidosPasos.Length == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, sonidosPasos.Length);
        audioSource.PlayOneShot(sonidosPasos[randomIndex]);
    }

    private void OnDrawGizmosSelected()
    {
        Collider2D c = GetComponent<Collider2D>();
        if (c != null)
        {
            Gizmos.color = Color.green;
            Vector3 origen = new Vector3(c.bounds.center.x, c.bounds.min.y - 0.02f, 0f);
            Gizmos.DrawLine(origen, origen + Vector3.down * distanciaSuelo);
        }
    }
}