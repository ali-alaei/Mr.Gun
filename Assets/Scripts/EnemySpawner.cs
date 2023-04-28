using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyPositions;
    [SerializeField] List<GameObject> enemiesPrefabs;
    
    private GameObject currentEnemy = null;
    private int enemySpawnerIndex = 0;


   

    // Update is called once per frame
    void Update()
    {

        SpawnEnemy();
    }


    public void SpawnEnemy()
    {

        while (enemySpawnerIndex < enemiesPrefabs.Count &&
            GameObject.FindWithTag("Enemy") == null)
        {

            if (enemySpawnerIndex % 2 == 1)
            {
                //Debug.Log("new enemy generated");
                currentEnemy = Instantiate(enemiesPrefabs[enemySpawnerIndex],
                    enemyPositions[enemySpawnerIndex].transform.position,
                    Quaternion.Euler(0f, 180f, 0f));
                
                
                currentEnemy.GetComponent<EnemyController>().enabled = false;
                


            }
            else if(enemySpawnerIndex % 2 == 0)
            {
                //Debug.Log("new enemy generated");
                currentEnemy = Instantiate(enemiesPrefabs[enemySpawnerIndex],
                    enemyPositions[enemySpawnerIndex].transform.position,
                    Quaternion.identity);


                currentEnemy.GetComponent<EnemyController>().enabled = false;
                

            }

            enemySpawnerIndex++;

        }
        

    }
}
