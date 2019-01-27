using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class miniGameSelector : MonoBehaviour
{
    public static miniGameSelector instance = null;
    public string[] gameNames;
    public int index;

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

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            nextScene();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void nextScene()
    {
        index++;

        if (index >= gameNames.Length) index = 0;

        SceneManager.LoadScene(gameNames[index]);
    }
}
