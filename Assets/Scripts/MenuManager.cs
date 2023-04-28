using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void OnEnable()
    {
        Actions.OnPlayerKilled += LoadGameOverMenu;
    }

    private void OnDisable()
    {
        Actions.OnPlayerKilled -= LoadGameOverMenu;
    }

    public void LoadGameOverMenu()
    {
        Debug.Log("GameOver");
        Invoke("LoadMenu", 1f);
       


    }

    void LoadMenu()
    {

        SceneManager.LoadScene("GameOverMenu");

    }
}
