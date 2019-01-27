using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class openingController : MonoBehaviour
{
    public GameObject slides;
    public Sprite opening1;
    public Sprite opening2;
    public Sprite opening3;
    public Sprite opening4;
    public Sprite opening5;

    int gameState = 0;
    public GameObject faderObject;
    SpriteRenderer faderSprite;
    SpriteRenderer sr;

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        faderSprite = faderObject.GetComponent<SpriteRenderer>();
        Color color = faderSprite.color;
        color.a = 1;
        faderSprite.color = color;
        sr = slides.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // fade in
        if (gameState == 0) {
            FadeIn();
        }
        else if (gameState == 1) {
            timer += Time.deltaTime;
            if (timer > 3 && timer < 6) {
                sr.sprite = opening2;
            }
            else if (timer > 6 && timer < 9) {
                sr.sprite = opening3;
            }
            else if (timer > 9 && timer < 12) {
                sr.sprite = opening4;
            }
            else if (timer > 12 && timer < 15) {
                sr.sprite = opening5;
            }
            else if (timer > 15) {
                FadeOut();
            }
        }
        else if (gameState == 2) {
            SceneManager.LoadScene("main");
        }
    }

    void FadeIn()
    {
        Color c = faderSprite.color;
        if (c.a > 0) {
            c.a -= 0.05f;
            faderSprite.color = c;
        }
        else {
            gameState++;
        }
    }

    void FadeOut()
    {
        Color c = faderSprite.color;
        if (c.a < 1) {
            c.a += 0.05f;
            faderSprite.color = c;
        }
        else {
            gameState++;
        }
    }
}
