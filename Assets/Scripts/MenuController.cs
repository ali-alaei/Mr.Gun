using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    private void OnEnable()
    {
        Actions.OnPlayerKilled += LoadGameOverMenu;
    }

    private void OnDisable()
    {
        Actions.OnPlayerKilled -= LoadGameOverMenu;
    }


    public void PlayGame()
    {

        SceneManager.LoadScene("Game");


    }

    public void QuitGame()
    {


        Debug.Log("Quit");

        Application.Quit();
    }

    public void LoadGameOverMenu()
    {

        SceneManager.LoadScene("GameOverMenu");


    }
}
