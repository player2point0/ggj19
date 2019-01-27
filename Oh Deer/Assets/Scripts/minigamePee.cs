using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minigamePee : MonoBehaviour
{
    public Camera cam;
    public GameObject pee;
    BoxCollider2D c;
    float moveSpeed = 0.1f;
    int directionX = -1;
    int directionY = -1;
    int minX = -4;
    int minY = -3;
    int maxX = 4;
    int maxY = 0;
    bool isLunging = false;
    bool isGameOver = false;

    float hits = 0.0f;
    float total = 0.0f;

    float timer = 0;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        c = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Vector3 pos = transform.position;
        timer += Time.deltaTime;

        if (timer >= 30) {
            Debug.Log("end");
        }
        else {
            if (Input.GetKey("right")) {
                transform.Translate((moveSpeed*0.75f)*-1.0f, 0, 0);
                cam.transform.Translate((moveSpeed*0.75f)*-1.0f, 0, 0);
            }
            else if (Input.GetKey("left")) {
                transform.Translate(moveSpeed*0.75f, 0, 0);
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

            transform.Translate(moveSpeed*directionX, moveSpeed*directionY, 0);
            cam.transform.Translate(moveSpeed*directionX, moveSpeed*directionY, 0);

            Vector3 peePos = pee.transform.position;
            peePos.y += 8;
            if (c.bounds.Contains(peePos)) {
                hits++;
            }
            total++;
            Debug.Log((hits/total)*100.0f +", " + timer);
        }

        if (!isLunging) {

        }
        else {
            if (!isGameOver) {
                transform.Translate(0, moveSpeed*5, 0);
                if (pos.y >= 3) {
                    if (pos.x >= -1 && pos.x <= 1) {
                        //audioSource.PlayOneShot(hit, 1F);
                    }
                    else {
                        //audioSource.PlayOneShot(miss, 1F);
                        SpriteRenderer sr = GetComponent<SpriteRenderer>();
                    }
                    isGameOver = true;
                }
            }
        }
    }
}
