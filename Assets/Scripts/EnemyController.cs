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
    private Transform playerTransform;
    Vector2 directionTowardPlayer;
    


    void Start()
    {

        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Debug.Log("Player Position:" + playerTransform.position);
        directionTowardPlayer = (playerTransform.position - transform.position).normalized;

    }

    
    void Update()
    {        
        
        if (!isTurnComplete)
        {

            Shoot();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //gameObject.SetActive(false);
            //gameObject.transform.position = new Vector3(5f, 4.88f, 0f);
            //gameObject.SetActive(true);

            Destroy(gameObject);
            

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
