using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurnManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    private GameObject currentEnemy;
    private bool isPlayerTurn = true;
    private bool enemySpawned = false;
    

    private void Start()
    {
        StartCoroutine(TurnCoroutine());
    }

    private void Update()
    {
        if (!enemySpawned)
        {
            currentEnemy = GameObject.FindWithTag("Enemy");
            if (currentEnemy != null)
            {
                currentEnemy.GetComponent<EnemyController>().enabled = false;
                enemySpawned = true;
            }
        }
    }

    private IEnumerator TurnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            if (isPlayerTurn) // player's turn
            {
                Debug.Log("player's turn");

                // switching to enemy
                if (player != null && currentEnemy != null &&
                    player.GetComponent<PlayerController>().isTurnComplete)
                {
                    isPlayerTurn = false;

                    // keep player's turn if enemy died
                    if (currentEnemy.GetComponent<EnemyController>().playerKilledEnemy)
                    {
                        currentEnemy.GetComponent<EnemyController>().playerKilledEnemy = false;
                    }
                    else
                    {
                        currentEnemy.GetComponent<EnemyController>().enabled = true;
                    }

                    player.GetComponent<PlayerController>().isTurnComplete = false;
                    Debug.Log("switched to enemy");
                    
                }
            }
            else // enemy's turn
            {
                Debug.Log("enemy's turn");

                // switching to player
                if (player != null && currentEnemy != null &&
                    currentEnemy.GetComponent<EnemyController>().isTurnComplete)
                {
                    isPlayerTurn = true;
                    currentEnemy.GetComponent<EnemyController>().enabled = false;
                    player.GetComponent<PlayerController>().enabled = true;
                    currentEnemy.GetComponent<EnemyController>().isTurnComplete = false;
                    Debug.Log("switched to player");
                }
            }
        }
    }

    
}



//public class TurnManager : MonoBehaviour
//{
//    [SerializeField] GameObject player;
//    //[SerializeField] GameObject enemy;

//    private GameObject currentEnemy = null;

//    private bool isPlayerTurn = true;


//    private void Start()
//    {
//        //enemy = GameObject.FindWithTag("Enemy");
//        player.GetComponent<PlayerController>().enabled = true;

//        // Commented in the case of the first enemy is also being instantiated and enables is set inside EnemySpawner.
//        //enemy.GetComponent<EnemyController>().enabled = false;

//        //Debug.Log("TurnManager has started");

//        StartCoroutine(TurnCoroutine());
//    }

//    private void Update()
//    {

//        if (currentEnemy == null)
//        {
//            currentEnemy = GameObject.FindWithTag("Enemy");
//            //Debug.Log("enemy name: " + enemy.name);
//        }
//    }





//    private IEnumerator TurnCoroutine()
//    {
//        while (true)
//        {
//            yield return new WaitForSeconds(3f);

//            if (isPlayerTurn)
//            {

//                //Debug.Log("enemy object = " + enemy);
//                //Debug.Log("player object = " + player);

//                Debug.Log("player's turn");
//                // player is done, switching to enemy
//                if (player != null && currentEnemy != null &&
//                    player.GetComponent<PlayerController>().isTurnComplete)
//                {
//                    Debug.Log("switched to enemy");
//                    isPlayerTurn = false;
//                    currentEnemy.GetComponent<EnemyController>().enabled = true;

//                    player.GetComponent<PlayerController>().isTurnComplete = false;
//                }
//            }

//            else
//            {
//                Debug.Log("enemy's turn");
//                // enemy is done, switching to player
//                if (player != null && currentEnemy != null &&
//                    currentEnemy.GetComponent<EnemyController>().isTurnComplete)
//                {
//                    Debug.Log("switched to player");
//                    isPlayerTurn = true;
//                    currentEnemy.GetComponent<EnemyController>().enabled = false;


//                    player.GetComponent<PlayerController>().enabled = true;
//                    currentEnemy.GetComponent<EnemyController>().isTurnComplete = false;
//                }
//            }
//        }
//    }
//}
