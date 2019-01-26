using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class miniGameController : MonoBehaviour
{
    public string miniGameName;
    public Transform playerSpawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(miniGameName);

        FindObjectOfType<sceneController>().openScene(miniGameName, playerSpawn);

        //Invoke("closeScene", 1);
    }

    private void closeScene()
    {
        SceneManager.UnloadSceneAsync(miniGameName);
    }
}
