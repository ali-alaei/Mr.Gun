using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public bool isTurnComplete; 
    public bool isEnemyAlive;
    [SerializeField] GameObject gun;
    [SerializeField] GameObject bulletPrefab;
    
    
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            isEnemyAlive = false;
        }
    }

    private void Shoot()
    {

        Debug.Log("Enemy Shoot");


    }
    // Start is called before the first frame update
    void Start()
    {
        isTurnComplete = false;
        isEnemyAlive = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTurnComplete && isEnemyAlive)
        {
            Shoot();
            isTurnComplete = true;
        }

        
        
    }
}
