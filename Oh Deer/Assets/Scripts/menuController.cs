using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menuController : MonoBehaviour
{
    public void openMainGame()
    {
        SceneManager.LoadScene("main");
    }

    public void exitGame()
    {
        Application.Quit();
    }


}
