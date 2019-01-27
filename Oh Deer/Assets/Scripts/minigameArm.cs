using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minigameArm : MonoBehaviour
{
    public Camera cam;
    public Sprite brokenSprite;
    float moveSpeed = 0.1f;
    int directionX = -1;
    int directionY = -1;
    int minX = -1;
    int minY = -3;
    int maxX = 11;
    int maxY = 0;
    bool isLunging = false;
    bool isGameOver = false;

    public AudioClip hit;
    public AudioClip miss;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector3 pos = transform.position;

        if (!isLunging) {
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

            if (Input.GetKeyDown("space")) {
                isLunging = true;
            }
        }
        else {
            if (!isGameOver) {
                transform.Translate(0, moveSpeed*5, 0);
                cam.transform.Translate(0, moveSpeed*5, 0);
                if (pos.y >= 3) {
                    if (pos.x >= -1 && pos.x <= 1) {
                        audioSource.PlayOneShot(hit, 1F);
                    }
                    else {
                        audioSource.PlayOneShot(miss, 1F);
                        SpriteRenderer sr = GetComponent<SpriteRenderer>();
                        sr.sprite = brokenSprite;
                    }
                    isGameOver = true;
                }
            }
        }
    }
}
