using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
   [SerializeField] GameObject player;

    
   [SerializeField] GameObject enemy;
   private bool isPlayerTurn;

    private void Awake()
    {
        isPlayerTurn = true;
    }
   private void Start()
   {
       
    //    player.GetComponent<PlayerController>().enabled = true;
    //    enemy.GetComponent<EnemyController>().enabled = false;
   }

   private void Update()
   {
        
       if (player != null && isPlayerTurn && !(player.GetComponent<PlayerController>().isTurnComplete))
       {
            // player's turn

           isPlayerTurn = false;
        //    player.GetComponent<PlayerController>().isTurnComplete = true;
        //    enemy.GetComponent<EnemyController>().enabled = true;
           player.GetComponent<PlayerController>().isTurnComplete = false;
       }
        
       else if (enemy != null && !isPlayerTurn && !(enemy.GetComponent<EnemyController>().isTurnComplete))
       {
            
            // enemy's turn

            isPlayerTurn = true;
            //    enemy.GetComponent<EnemyController>().enabled = false;
            //    player.GetComponent<PlayerController>().enabled = true;
            enemy.GetComponent<EnemyController>().isTurnComplete = true;
          
       
       }
   }
}
