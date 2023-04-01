using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public bool isTurnComplete = false; 
    
    [SerializeField] GameObject gun;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject firePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 2f;
    //private float nextFire = 0.0f;
    private Transform playerTransform;
    private Rigidbody2D rb;
    Vector2 directionTowardPlayer;


    void Start()
    {
        
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //Debug.Log("player position: " + playerTransform.position);
        //Debug.Log("enemy position: " + playerTransform.position);

        directionTowardPlayer = (playerTransform.position - transform.position).normalized;
        //Debug.Log("directionTowardPlayer: " + directionTowardPlayer);
    }

    
    void Update()
    {
        if (!isTurnComplete)
        {
            Debug.Log("Enemy's turn");
            Shoot();

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
           
        }
    }

    private void Shoot()
    {
        
        GameObject bullet = Instantiate(bulletPrefab,
            firePoint.transform.position, Quaternion.identity);

        // set the bullet's velocity and direction
        bullet.GetComponent<Rigidbody2D>().velocity = directionTowardPlayer * bulletSpeed;

        isTurnComplete = true;


    }
    
}
