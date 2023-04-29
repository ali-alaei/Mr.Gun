using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void OnEnable()
    {
        Actions.OnPlayerKilled += LoadGameOverMenuWithDelay;
        Actions.OnPlayerWon += LoadWonMenuWithDelay;
    }

    private void OnDisable()
    {
        Actions.OnPlayerKilled -= LoadGameOverMenuWithDelay;
        Actions.OnPlayerWon -= LoadWonMenuWithDelay;
    }

    public void LoadGameOverMenuWithDelay()
    {
        //Debug.Log("GameOver");
        Invoke("LoadGameOverMenu", 3f);
       


    }

    public void LoadWonMenuWithDelay()
    {
        //Debug.Log("You Won");
        Invoke("LoadWonMenu", 3f);



    }

    void LoadWonMenu()
    {


        SceneManager.LoadScene("WonMenu");

    }





    void LoadGameOverMenu()
    {

        SceneManager.LoadScene("GameOverMenu");

    }
}
