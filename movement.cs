using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public Rigidbody2D rb;

    public float gravity = -9.81f;

    Vector2 movedir;
    Vector2 velocity;
    Vector2 playerMovement;


    bool isGrounded;
    public Transform groundcheck;
    public LayerMask whatIsGround;

    public Animator animator;
    playerHealh healh;
    // Start is called before the first frame update
    void Start()
    {
        healh = GetComponent<playerHealh>();
    }

    // Update is called once per frame
    void Update()
    {
        if(healh.isCompleted != true)
        {
            isGrounded = Physics2D.OverlapCircle(groundcheck.position, 0.1f, whatIsGround);

            if (isGrounded && velocity.y <= 0f)
            {
                velocity.y = -2f;
            }
            if (Input.GetButtonDown("Jump") && isGrounded == true)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }

            movedir.x = Input.GetAxis("Horizontal");

            animator.SetFloat("move", Mathf.Abs(movedir.x));

            velocity.y += gravity * Time.deltaTime;

            playerMovement = new Vector2(movedir.x * (speed * 10f), velocity.y * 10f);



            if (movedir.x > 0f)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            if (movedir.x < 0)
            {
                transform.localScale = new Vector2(1, 1);
            }
        }
        else
        {
            playerMovement.x = 0f;
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = playerMovement* Time.fixedDeltaTime;
    }
}
