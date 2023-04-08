using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    //[SerializeField] GameObject enemy;

    private GameObject enemy = null;

    private bool isPlayerTurn = true;


    private void Awake()
    {
        enemy = GameObject.FindWithTag("Enemy");
        player.GetComponent<PlayerController>().enabled = true;

    }

    private void Start()
    {

        // Commented in the case of the first enemy is also being instantiated and enables is set inside EnemySpawner.
        //enemy.GetComponent<EnemyController>().enabled = false;

        //Debug.Log("TurnManager has started");

        StartCoroutine(TurnCoroutine());
    }

    private void Update()
    {
        
        if (enemy == null)
        {
            enemy = GameObject.FindWithTag("Enemy");
        }
    }
        
        



    private IEnumerator TurnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            

            if (isPlayerTurn)
            {


                Debug.Log("enemy object = " + enemy);
                Debug.Log("player object = " + player);

                //Debug.Log("player's turn");
                // player's turn
                if (player != null && enemy != null &&
                    player.GetComponent<PlayerController>().isTurnComplete)
                {
                    //Debug.Log("Transitioning to enemy's turn");
                    isPlayerTurn = false;
                    enemy.GetComponent<EnemyController>().enabled = true;
                    player.GetComponent<PlayerController>().isTurnComplete = false;
                }
            }

            else
            {
                //Debug.Log("enemy's turn");
                // enemy's turn
                if (player != null && enemy != null &&
                    enemy.GetComponent<EnemyController>().isTurnComplete)
                {
                    //Debug.Log("Transitioning to player's turn");
                    isPlayerTurn = true;
                    enemy.GetComponent<EnemyController>().enabled = false;
                    player.GetComponent<PlayerController>().enabled = true;
                    enemy.GetComponent<EnemyController>().isTurnComplete = false;
                }
            }
        }
    }
}
