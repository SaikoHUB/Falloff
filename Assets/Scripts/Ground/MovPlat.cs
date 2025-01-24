using UnityEngine;

public class MovPlat : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 5f;
    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingRight = true;
    private Rigidbody2D rb;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + new Vector3(distance, 0, 0);
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D manquant sur l'objet MovPlat !");
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Kinematic; // Utilisez bodyType à la place de isKinematic
            rb.gravityScale = 0; // Assurez-vous que la gravité est désactivée
        }
    }

    void Update()
    {
        // Move the platform towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // Check if the platform has reached the target position
        if (Vector3.Distance(transform.position, targetPos) < 0.01f)
        {
            // Switch direction
            if (movingRight)
            {
                targetPos = startPos - new Vector3(distance, 0, 0);
            }
            else
            {
                targetPos = startPos + new Vector3(distance, 0, 0);
            }
            movingRight = !movingRight;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}