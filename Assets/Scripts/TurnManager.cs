using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class TurnManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] EnemySpawner enemySpawner;
    private GameObject currentEnemy;

    private TurnState currentState;

    private enum TurnState
    {
        PlayerTurn,
        WaitingForShotResult,
        EnemyTurn


    }

    private void Awake()
    {
        this.currentState = TurnState.PlayerTurn;
        enemySpawner.SpawnEnemy();
        currentEnemy = GameObject.FindWithTag("Enemy");
        currentEnemy.GetComponent<EnemyController>().enabled = false;

    }

    private void Start()
    {
        
        // StartCoroutine(TurnCoroutine());
    }


    private void Update()
    {
        if (currentEnemy == null)
        {
            enemySpawner.SpawnEnemy();
            currentEnemy = GameObject.FindWithTag("Enemy");
        }
    }

    public void OnPlayerShotStarted()
    {
        if (currentState == TurnState.PlayerTurn)
        {
            this.currentState = TurnState.WaitingForShotResult;
        }
    }

    public void OnPlayerShotResolved(bool hit)
    {
        if (currentState == TurnState.WaitingForShotResult && !hit)
        {
            this.currentState = TurnState.EnemyTurn;
            if (currentEnemy != null)
            {
                currentEnemy.GetComponent<EnemyController>().enabled = true;
            } 
        }
        else if (currentState == TurnState.WaitingForShotResult && hit)
        {
            this.currentState = TurnState.PlayerTurn;
        }
    }


    // private IEnumerator TurnCoroutine()
    // {
    //     while (true)
    //     {

    //         Debug.Log($"Before yield return at t={Time.time:F2}");

    //         yield return new WaitForSeconds(5f);

    //         Debug.Log($"After yield return at t={Time.time:F2}");


    //         // switching to enemy
    //         if (PlayerController.hasShot && !EnemyCollisionController.isDead)

    //         {

    //             Debug.Log($"[TurnManager] About to switch to ENEMY at t={Time.time:F2} | hasShot={PlayerController.hasShot} | enemyDead={EnemyCollisionController.isDead} | enemyNull={(currentEnemy == null)}");


    //             currentEnemy.GetComponent<EnemyController>().enabled = true;


    //             Debug.Log($"[TurnManager] Switched to ENEMY at t={Time.time:F2}");
                    
    //         }
         

    //     }
    // }
        
}

