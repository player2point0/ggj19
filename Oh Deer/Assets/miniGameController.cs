using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class miniGameController : MonoBehaviour
{
    public Scene miniGame;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.SetActiveScene(miniGame);
    }
}
