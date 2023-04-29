using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100.0f;
    [SerializeField] float rotationAngle = 30.0f;
    [SerializeField] GameObject gun;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject firePoint;
    [SerializeField] float shootingForce = 10.0f;
    [SerializeField] float playerMoveSpeed = 2.0f;
    [SerializeField] Animator gunAnimator;
    [SerializeField] List<GameObject> enemyPositions;
    [SerializeField] ParticleSystem explosionPrefab;

    private AudioSource shootingSound;
    private float currentAngle;
    public static bool hasShot;
    private GameObject enemy;
    private Transform playerTransform;
    private int enemyPositionIndex = 0;

    void Start()
    {
        hasShot = false;
        shootingSound = GetComponent<AudioSource>();

    }

    private void OnEnable()
    {
        Actions.OnEnemyKilled += DelayMove;
        

    }

    private void OnDisable()
    {
        Actions.OnEnemyKilled -= DelayMove;
    }

    void Update()
    {

        
        GunRotator();
        BulletShooter();
    }

    

    void DelayMove()
    {

        Invoke("Move", 1);

    }


    void Move()
    {
        Actions.OnPlayerMove?.Invoke();
        StartCoroutine(MoveToNextPosition());

    }

    IEnumerator MoveToNextPosition()
    {
        // Disable player control during movement
        GetComponent<PlayerController>().enabled = false;

        // Calculate the distance to the target position
        float distance = Vector2.Distance(transform.position, enemyPositions[enemyPositionIndex].transform.position);

        // Move the player towards the target position until they reach it
        while (distance > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                enemyPositions[enemyPositionIndex].transform.position, playerMoveSpeed * Time.deltaTime);
            distance = Vector3.Distance(transform.position, enemyPositions[enemyPositionIndex].transform.position);
            yield return null;
            //yield return new WaitForSeconds(0.5f);

        }

        // Re-enable player control after movement is complete
        GetComponent<PlayerController>().enabled = true;

        Flip();
        enemyPositionIndex++;

    }

    private void Flip()
    {
        Vector3 newRotation = transform.rotation.eulerAngles;
        newRotation.y += 180f;
        transform.rotation = Quaternion.Euler(newRotation);
    }


    void GunRotator()
    {
        
        float normalizedTime = Mathf.PingPong(Time.time * rotationSpeed, 1.0f);
        currentAngle = Mathf.Lerp(0.0f, rotationAngle, normalizedTime);
        //gun.transform.rotation = Quaternion.Euler(0, 0, currentAngle);

        // Get the current rotation of the gun
        Quaternion currentRotation = gun.transform.rotation;

        // Calculate the new rotation around the Z-axis
        Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x,
            currentRotation.eulerAngles.y, currentAngle);

        // Set the new rotation of the gun
        gun.transform.rotation = newRotation;
    }

    void BulletShooter()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasShot)
        {
            
            GameObject bullet = Instantiate(bulletPrefab,
                firePoint.transform.position, firePoint.transform.rotation);
            shootingSound.Play();
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(gun.transform.right * shootingForce);
            gunAnimator.SetTrigger("Shoot");
            hasShot = true;
          
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Actions.OnPlayerKilled.Invoke();
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity).Play();
            Destroy(gameObject);

        }
    }




}
