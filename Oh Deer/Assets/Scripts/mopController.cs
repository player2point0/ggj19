using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mopController : MonoBehaviour
{
    public float speed;

    private int score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject, 0.25f);
        score++;
    }

    void FixedUpdate()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        this.transform.position = Vector2.MoveTowards(this.transform.position, pos, speed);
    }
}
