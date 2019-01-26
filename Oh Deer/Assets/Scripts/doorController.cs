using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    public doorController nextRoom;
    public GameObject currentRoom;
    public Transform playerSpawn;//spawn for current room

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //open new room
        nextRoom.transform.parent.gameObject.SetActive(true);
        //reposition player
        player.transform.position = nextRoom.playerSpawn.position;
        //hide current room
        currentRoom.gameObject.SetActive(false);
    }

}
