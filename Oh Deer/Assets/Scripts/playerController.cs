using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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

    private Rigidbody2D rb;
    private float noiseLevel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        noiseLevel = 0;
        noiseSlider.value = noiseLevel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        noiseLevel += noiseIncrease;

        noiseSlider.value = noiseLevel;

        if (noiseLevel > 1) gameOver();
    }

    void FixedUpdate()
    {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        if(x !=0 || y != 0)
        {
            if(Random.value > (1 - stumbleChance)) Stumble();

            Vector2 move = new Vector2(x, y);

            rb.AddForce(move * speed);
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

        rb.AddForce(move);
    }

    void gameOver()
    {
        Debug.Log("game over");
    }

}
