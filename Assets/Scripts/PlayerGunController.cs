using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100.0f;
    [SerializeField] float rotationAngle = 30.0f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject firePoint;
    [SerializeField] float shootingForce = 10.0f;
    private float currentAngle;


    void GunRotator()
    {
        float normalizedTime = Mathf.PingPong(Time.time * rotationSpeed, 1.0f);
        currentAngle = Mathf.Lerp(0.0f, rotationAngle, normalizedTime);
        transform.rotation = Quaternion.Euler(0, 180, currentAngle);
    }

    void ResetGunZRotationAxis()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    void BulletShooter()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.right * shootingForce);
            
        }

    }

    void Start()
    {
        ResetGunZRotationAxis();
    }

    void Update()
    {
        GunRotator();
        BulletShooter();
    }

    
}
