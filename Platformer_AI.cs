using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer_AI : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;

    public Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void FixedUpdate()
    {
        rb.position += dir * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            dir.x *= -1;
            transform.localScale = new Vector3(-dir.x, 1, 1);
        }
    }
}
