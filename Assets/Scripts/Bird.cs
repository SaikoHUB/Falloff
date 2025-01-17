using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speed = 12f;
    public float moveTime = 10f;
    public float pushForce = 1000f; // Force de poussée appliquée au joueur
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float moveTimer;
    private bool movingRight = true;

    void Start()
    {
        startPosition = new Vector3(-10, transform.position.y, transform.position.z);
        endPosition = new Vector3(15, transform.position.y, transform.position.z);
        moveTimer = moveTime;
    }

    void Update()
    {
        moveTimer -= Time.deltaTime;
        if (moveTimer <= 0)
        {
            movingRight = !movingRight;
            moveTimer = moveTime;
        }

        if (movingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                Vector2 forceDirection = movingRight ? Vector2.right : Vector2.left;
                playerRb.AddForce(new Vector2(forceDirection.x * pushForce, 1000));
            }
        }
    }
}