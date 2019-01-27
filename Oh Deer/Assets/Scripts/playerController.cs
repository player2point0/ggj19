using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;
    public float stumbleSpeed;
    public float stumbleAngleMax;
    public float stumbleAngleMin;
    public float stumbleChance;
    public float noiseIncrease;
    public Slider noiseSlider;
    public Image noiseAlert;
    public float noiseAlertDuration;
    public Image gameOverImage;

    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float noiseLevel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        noiseLevel = 0;
        noiseSlider.value = noiseLevel;

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        noiseLevel += noiseIncrease;

        noiseSlider.value = noiseLevel;

        showNoiseAlert();

        Invoke("hideNoiseAlert", noiseAlertDuration);

        if (noiseLevel > 1) StartCoroutine("gameOver");
    }

    void showNoiseAlert()
    {
        noiseAlert.gameObject.SetActive(true);
    }

    void hideNoiseAlert()
    {
        noiseAlert.gameObject.SetActive(false);
    }
    
    void FixedUpdate()
    {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        animator.SetBool("buttonPress", (x != 0 || y != 0));

        if(x !=0 || y != 0)
        {
            if(Random.value > (1 - stumbleChance)) Stumble();

            Vector2 move = new Vector2(x, y);

            rb.AddForce(move * speed);

            if (x > 0) {
                spriteRenderer.flipX = true;
            } else if(x < 0)
            {
                spriteRenderer.flipX = false;
            }
        }
        
    }
    
    void Stumble()
    {
        float x = rb.velocity.x;
        float y = rb.velocity.y;
        float angle = Mathf.Atan(x / y);

        if (Random.value >= 0.5)
        {
            angle += Mathf.Deg2Rad * Random.Range(stumbleAngleMin, stumbleAngleMax);
        }

        else
        {
            angle -= Mathf.Deg2Rad * Random.Range(stumbleAngleMin, stumbleAngleMax);
        }

        x = Mathf.Sin(angle) * stumbleSpeed;
        y = Mathf.Cos(angle) * stumbleSpeed;

        Vector2 move = new Vector2(x, y);

        if (float.IsNaN(x) || float.IsNaN(y)) return;

        rb.AddForce(move);
    }

    IEnumerator gameOver()
    {
        gameOverImage.gameObject.SetActive(true);
        
        while(true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //load main game 
                SceneManager.LoadScene("main");
            }

            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                //load main menu
                SceneManager.LoadScene("MainMenu");
            }

            yield return null;
        }

    }
    
}
