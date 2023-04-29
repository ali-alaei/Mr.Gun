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

            yield return new WaitForSeconds(5f);

            // switching to enemy
            if (PlayerController.hasShot && !EnemyCollisionController.isDead)

            {

                currentEnemy.GetComponent<EnemyController>().enabled = true;
                Debug.Log("switched to enemy");
                    
            }
         

        }
    }
        
}

