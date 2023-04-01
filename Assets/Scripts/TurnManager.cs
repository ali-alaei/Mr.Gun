//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;



//public class TurnManager : MonoBehaviour
//{
//    [SerializeField] GameObject player;
//    [SerializeField] GameObject enemy;

//    private bool isPlayerTurn = true;

//    private void Start()
//    {
//        player.GetComponent<PlayerController>().enabled = true;
//        enemy.GetComponent<EnemyController>().enabled = false;
//    }

//    private void Update()
//    {

//        // if it was player's turn, switch to enemy's turn
//        if (player.activeSelf && isPlayerTurn &&
//            player.GetComponent<PlayerController>().isTurnComplete)
//        {
//            Debug.Log("Transitioning to enemy's turn");
//            //isPlayerTurn = false;
//            isPlayerTurn = !isPlayerTurn;
//            enemy.GetComponent<EnemyController>().enabled = true;


//            player.GetComponent<PlayerController>().isTurnComplete = false;


//        }

//        // if it was enemy's turn, switch to player's turn
//        else if (enemy.activeSelf && !isPlayerTurn &&
//            enemy.GetComponent<EnemyController>().isTurnComplete)
//        {
//            Debug.Log("Transitioning to player's turn");
//            //isPlayerTurn = true;
//            isPlayerTurn = !isPlayerTurn;
//            enemy.GetComponent<EnemyController>().enabled = false;
//            player.GetComponent<PlayerController>().enabled = true;
//            enemy.GetComponent<EnemyController>().isTurnComplete = false;
//        }
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;

    private bool isPlayerTurn = true;

    private void Start()
    {
        player.GetComponent<PlayerController>().enabled = true;
        enemy.GetComponent<EnemyController>().enabled = false;

        // start the turn coroutine
        StartCoroutine(TurnCoroutine());
    }

    private IEnumerator TurnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f); // wait one frame

            if (isPlayerTurn)
            {
                // player's turn
                if (player.activeSelf && player.GetComponent<PlayerController>().isTurnComplete)
                {
                    Debug.Log("Transitioning to enemy's turn");
                    isPlayerTurn = false;
                    enemy.GetComponent<EnemyController>().enabled = true;
                    player.GetComponent<PlayerController>().isTurnComplete = false;
                }
            }
            else
            {
                // enemy's turn
                if (enemy.activeSelf && enemy.GetComponent<EnemyController>().isTurnComplete)
                {
                    Debug.Log("Transitioning to player's turn");
                    isPlayerTurn = true;
                    enemy.GetComponent<EnemyController>().enabled = false;
                    player.GetComponent<PlayerController>().enabled = true;
                    enemy.GetComponent<EnemyController>().isTurnComplete = false;
                }
            }
        }
    }
}
