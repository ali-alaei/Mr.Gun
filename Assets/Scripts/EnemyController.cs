using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] GameObject gun;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject firePoint;

    public bool isTurnComplete = false;
    
    public float bulletSpeed = 10f;
    private Transform playerTransform;
    private AudioSource shootingSound;

    Vector2 directionTowardPlayer;
    


    void Start()
    {
        
        shootingSound = GetComponent<AudioSource>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //Debug.Log("Player Position:" + playerTransform.position);
        directionTowardPlayer = (playerTransform.position - transform.position).normalized;

    }

    
    void Update()
    {        
        
        if (!isTurnComplete)
        {
            //Debug.Log("Enemy has shot");
            Shoot();

        }
        
    }

   


    private void Shoot()
    {
        shootingSound.Play();
        GameObject bullet = Instantiate(bulletPrefab,
            firePoint.transform.position, Quaternion.identity);

        // set the bullet's velocity and direction
        bullet.GetComponent<Rigidbody2D>().velocity = directionTowardPlayer * bulletSpeed;

        isTurnComplete = true;

    }

    
}
