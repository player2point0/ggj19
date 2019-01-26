using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class sceneController : MonoBehaviour
{
    public static sceneController instance = null;

    private Vector2 playerPos;
    private GameObject room;

    void Awake()
    {
        // creates a singleton manager that persists between scenes
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void openScene(string name, Transform playerSpawn)
    {
        //check if current scene is a mini game
        if(playerSpawn == null)
        {
            //if mini game then load the main scene with the saved room and player positon
            SceneManager.LoadScene("main");
            
            GameObject[] rooms = GameObject.FindGameObjectsWithTag("room");

            for(int i = 0;i<rooms.Length;i++)
            {
                if (rooms[i].name == room.name) rooms[i].SetActive(true);

                else rooms[i].SetActive(false);
            }

            StartCoroutine("placePlayerSpawn");
        }

        else
        {
            //else save the current room and player posistion   
            GameObject[] rooms = GameObject.FindGameObjectsWithTag("room");

            for (int i = 0; i < rooms.Length; i++)
            {
                if (rooms[i].activeSelf)
                {
                    room = rooms[i];
                }
            }

            playerPos = playerSpawn.position;

            SceneManager.LoadScene(name);
        }
    }


    public IEnumerator placePlayerSpawn()
    {
        int crashCounter = 0;

        while(crashCounter < 10000)
        {
            playerController player = FindObjectOfType<playerController>();

            if (player != null)
            {
                player.transform.position = playerPos;
                break;                
            }

            crashCounter++;
            yield return null;
        }
    }
}
