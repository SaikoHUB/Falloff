using UnityEngine;

public class BirdFly : MonoBehaviour
{
    public float speed = 2f; // Speed of the platform movement
    public float distance = 5f; // Distance the platform will move
    public float pushForce = 20f; // Increased force applied to the player

    private Vector3 startPosition;
    private bool movingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Oscillate the platform back and forth
        float newPosition = Mathf.PingPong(Time.time * speed, distance);
        transform.position = startPosition + new Vector3(newPosition, 0, 0);

        // Determine the direction of movement
        if (newPosition > distance / 2 && !movingRight)
        {
            Flip();
            movingRight = true;
        }
        else if (newPosition <= distance / 2 && movingRight)
        {
            Flip();
            movingRight = false;
        }
    }

    void Flip()
    {
        // Flip the bird by inverting the x scale
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                ContactPoint2D contact = collision.GetContact(0);
                Vector2 forceDirection = (contact.point - (Vector2)transform.position).normalized;
                playerRb.AddForce(-forceDirection * pushForce, ForceMode2D.Impulse);
                Debug.Log("Player pushed with force: " + (-forceDirection * pushForce));
            }
        }
    }
}