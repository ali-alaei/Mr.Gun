using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class TurnManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] EnemySpawner enemySpawner;
    private GameObject currentEnemy;

    private void Awake()
    {
        // init it's player's turn
        //player.GetComponent<PlayerController>().enabled = true;
        //// disables enemy shooting at the beginning
        //currentEnemy = GameObject.FindWithTag("Enemy");

        enemySpawner.SpawnEnemy();
        currentEnemy = GameObject.FindWithTag("Enemy");
        currentEnemy.GetComponent<EnemyController>().enabled = false;

    }

    private void Start()
    {
        
        StartCoroutine(TurnCoroutine());
    }


    private void Update()
    {
        if (player == null)
        {
            // stop the game
            //EditorApplication.isPlaying = false;
            Debug.Log("Game Over");

        }

        if (currentEnemy == null)
        {
            enemySpawner.SpawnEnemy();
            currentEnemy = GameObject.FindWithTag("Enemy");
            
        }

    }


    private IEnumerator TurnCoroutine()
    {
        while (true)
        {

            yield return new WaitForSeconds(3f);

            
            

            // switching to enemy
            if (/*player.GetComponent<PlayerController>().hasShot*/ PlayerController.hasShot && !EnemyCollisionController.isDead)
                //!(currentEnemy.GetComponent<EnemyCollisionController>().isDead))

            {
                   

                // keep player's turn if enemy died
                //if (currentEnemy.GetComponent<EnemyController>().playerKilledEnemy)
                //{
                //    currentEnemy.GetComponent<EnemyController>().playerKilledEnemy = false;
                //}
                //else
                //{
                //    currentEnemy.GetComponent<EnemyController>().enabled = true;
                //}
                currentEnemy.GetComponent<EnemyController>().enabled = true;

                //player.GetComponent<PlayerController>().isTurnComplete = false;
                Debug.Log("switched to enemy");
                    
            }
            //else
            //{
            //    player.GetComponent<PlayerController>().hasShot = false;
            //}

            




        }
    }
        
}

