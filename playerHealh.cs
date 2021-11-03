using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealh : MonoBehaviour
{
    public int healthPoints = 5;
    public Image[] heart;
    public Sprite emptyHealth;
    private Rigidbody2D rb;

    private GameObject gameOverScreen;
    private GameObject victoryScreen;
    public bool isCompleted;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameOverScreen = GameObject.FindGameObjectWithTag("GameOver");
        gameOverScreen.SetActive(false);
        victoryScreen = GameObject.FindGameObjectWithTag("Finish");
        victoryScreen.SetActive(false);
        isCompleted = false;
    }
    void Update()
    {
        if (healthPoints <= 0)
        {
            gameOverScreen.SetActive(true);
            Destroy(gameObject);
        }
    }
    void Damage()
    {
        camShake.instance.Shake(10f, 0.1f);
        healthPoints -= 1;
        heart[healthPoints].sprite = emptyHealth;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("enemy"))
        {
            StartCoroutine(knockBack(0.2f, 350f));
            Damage();
        }      
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("water"))
        {
            StartCoroutine(knockBack(0.2f, 350f));
            Damage();
        }
        if (collision.CompareTag("Flag"))
        {
            //levelcomplete
            isCompleted = true;
            victoryScreen.SetActive(true);
        }
    }

    IEnumerator knockBack(float knockbackTime,float knockbackPower)
    {
        float timer = 0f;

        while (knockbackTime > timer)
        {
            timer += Time.deltaTime;
            rb.AddForce(new Vector2(transform.position.x * -200f, transform.position.y + knockbackPower));
        }

        yield return 0;
    }
}
