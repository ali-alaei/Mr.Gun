using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public bool isTurnComplete = false; 
    
    [SerializeField] GameObject gun;
    [SerializeField] GameObject bulletPrefab;
    
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
           
        }
    }

    private void Shoot()
    {

        isTurnComplete = true;


    }
    // Start is called before the first frame update
    void Start()
    {
    
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Enemy's turn");


        
        
    }
}
