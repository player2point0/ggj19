using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class minigamePeeController : MonoBehaviour
{
    int gameState = 0;
    public GameObject faderObject;
    SpriteRenderer faderSprite;
    public GameObject instructionsObject;
    SpriteRenderer instructionsSprite;
    public Text scoreText;
    public GameObject success;

    public Camera cam;
    public GameObject pee;
    public GameObject toilet;
    BoxCollider2D c;
    float moveSpeed = 0.1f;
    int directionX = -1;
    int directionY = -1;
    int minX = -4;
    int minY = -3;
    int maxX = 4;
    int maxY = 0;

    float hits = 0.0f;
    float total = 0.0f;
    float score = 0f;

    float timer = 0;

    void Start()
    {
        c = toilet.GetComponent<BoxCollider2D>();
        faderSprite = faderObject.GetComponent<SpriteRenderer>();
        instructionsSprite = instructionsObject.GetComponent<SpriteRenderer>();
        Color color = faderSprite.color;
        color.a = 1;
        faderSprite.color = color;
        color = instructionsSprite.color;
        color.a = 1;
        instructionsSprite.color = color;
    }

    void Update()
    {
        // fade in
        if (gameState == 0) {
            FadeIn();
        }
        // show instructions
        else if (gameState == 1) {
            if (Input.GetKeyDown("space")) {
                gameState++;                
            }
        }
        // fading out
        else if (gameState == 2) {
            FadeOut();
        }
        // fading in
        else if (gameState == 3) {
            instructionsObject.SetActive(false);
            FadeIn();
            timer = 20;
        }
        // game start
        else if (gameState == 4) {
            GameLoop();
        }
        // game end
        else if (gameState == 5) {
            pee.SetActive(false);
            success.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -1);
            faderObject.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -1);
            scoreText.gameObject.SetActive(false);
            success.SetActive(true);
            timer = 5;
            gameState++;
        }
        else if (gameState == 6) {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                FadeOut();
            }
        }
        else if (gameState == 7) {

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

    void GameLoop() {
        Vector3 pos = toilet.transform.position;
        timer -= Time.deltaTime;

        if (timer <= 0) {
            gameState++;
        }
        else {
            if (Input.GetKey("right")) {
                toilet.transform.Translate((moveSpeed*0.75f)*-1.0f, 0, 0);
                cam.transform.Translate((moveSpeed*0.75f)*-1.0f, 0, 0);
            }
            else if (Input.GetKey("left")) {
                toilet.transform.Translate(moveSpeed*0.75f, 0, 0);
                cam.transform.Translate(moveSpeed*0.75f, 0, 0);
            }

            if (pos.x <= minX) {
                directionX = 1;
            }
            else if (pos.x >= maxX) {
                directionX = -1;
            }

            if (pos.y <= minY) {
                directionY = 1;
            }
            else if (pos.y >= maxY) {
                directionY = -1;
            }

            toilet.transform.Translate(moveSpeed*directionX, moveSpeed*directionY, 0);
            cam.transform.Translate(moveSpeed*directionX, moveSpeed*directionY, 0);

            Vector3 peePos = pee.transform.position;
            peePos.y += 8;
            if (c.bounds.Contains(peePos)) {
                hits++;
            }
            total++;
            score = (hits/total)*100.0f;
            scoreText.text = "Score: " + Mathf.Round(score).ToString() + "%";
        }
    }
}
