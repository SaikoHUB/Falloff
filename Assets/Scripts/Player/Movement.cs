using UnityEditor.Rendering;
using UnityEngine;


public class Movement : MonoBehaviour
{

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = 2f;
        rb.gravityScale = 2f;
        rb.freezeRotation = true; // Ensure the Rigidbody2D does not rotate
    }
   public Animator animator;
    public float speed = 5f;
    public float jumpForce = 12f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true; // Ensure the Rigidbody2D does not rotate
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Bird"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
