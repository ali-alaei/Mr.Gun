using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyPositions;
    [SerializeField] List<GameObject> enemiesPrefabs;
    private GameObject currentEnemy = null;
    private int enemySpawnerIndex = 0;


    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {

        GenerateEnemy();
    }


    void GenerateEnemy()
    {

        while (enemySpawnerIndex < enemiesPrefabs.Count &&
            GameObject.FindWithTag("Enemy") == null)
        {

            if (enemySpawnerIndex % 2 == 1)
            {
                //Debug.Log("new enemy generated");
                currentEnemy = Instantiate(enemiesPrefabs[enemySpawnerIndex],
                    enemyPositions[enemySpawnerIndex].transform.position, Quaternion.Euler(0f, 180f, 0f));
                currentEnemy.GetComponent<EnemyController>().enabled = false;
                // currentEnemy.GetComponent<EnemyController>().canShoot = false;


            }
            else
            {
                //Debug.Log("new enemy generated");
                currentEnemy = Instantiate(enemiesPrefabs[enemySpawnerIndex],
                    enemyPositions[enemySpawnerIndex].transform.position, Quaternion.identity);
                currentEnemy.GetComponent<EnemyController>().enabled = false;
                // currentEnemy.GetComponent<EnemyController>().canShoot = false;

            }

            enemySpawnerIndex++;

        }

    }
}
