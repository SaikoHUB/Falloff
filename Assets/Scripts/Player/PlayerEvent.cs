using UnityEngine;

public class PlayerEvent : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.mass = Mathf.Max(rb.mass, 0.1f); // Ensure mass is positive
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {
            if (rb != null)
            {
                rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
            }
        }
    }
}