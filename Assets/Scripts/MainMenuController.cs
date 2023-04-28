using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public void PlayGame()
    {

        SceneManager.LoadScene("Game");


    }

    public void ReplayGame()
    {

        SceneManager.LoadScene("MainMenu");

    }

    public void QuitGame()
    {


        Debug.Log("Quit the Game");

        Application.Quit();
    }

    
}
