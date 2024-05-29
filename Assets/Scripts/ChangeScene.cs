using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{   
    private bool tutorialPlayed = false;
    public void SceneChange()
    {
        if(tutorialPlayed == true)
        {
            SceneManager.LoadScene(1); //Game
        }
        else
        {
            SceneManager.LoadScene(2); //Tutorial
        }
    }   

    public void ExitGame()
    {
        Application.Quit();
    }
}
