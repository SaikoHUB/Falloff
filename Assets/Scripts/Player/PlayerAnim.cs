using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()   
    {
        float speed = rb.linearVelocity.magnitude;

        if (speed > 0.1f)
        {
            animator.Play("Player_Run");
        }
        else
        {
            animator.Play("Player_Idle");
        }
    }
}