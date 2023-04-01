using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100.0f;
    [SerializeField] float rotationAngle = 30.0f;
    [SerializeField] GameObject gun;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject firePoint;
    [SerializeField] float shootingForce = 10.0f;
    private float currentAngle;
    public bool isTurnComplete = false;
    


    void Start()
    {

        ResetGunZRotationAxis();
    }

    void Update()
    {
        Debug.Log("player's turn");
        GunRotator();
        BulletShooter();
    }


    void GunRotator()
    {
        
        float normalizedTime = Mathf.PingPong(Time.time * rotationSpeed, 1.0f);
        currentAngle = Mathf.Lerp(0.0f, rotationAngle, normalizedTime);
        gun.transform.rotation = Quaternion.Euler(0, 180, currentAngle);
    }

    void ResetGunZRotationAxis()
    {
        gun.transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    void BulletShooter()
    {
        
        
        if (Input.GetKeyDown(KeyCode.Space) && !isTurnComplete)
        {
      
            GameObject bullet = Instantiate(bulletPrefab,
                firePoint.transform.position, firePoint.transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(gun.transform.right * shootingForce);
            isTurnComplete = true;
            

        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);

        }
    }




}
