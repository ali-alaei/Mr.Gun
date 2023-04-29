using System.Collections;
using System.Collections.Generic;
using EZCameraShake;
using UnityEngine;

public class EnemyCollisionController : MonoBehaviour
{
    
    [SerializeField] ParticleSystem explosionPrefab;
    public static bool isDead;
    private AudioSource explosionSound;

    private void Start()
    {
        Debug.Log("EnemyCollision started");
        isDead = false;
        explosionSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
           
            isDead = true;
            Actions.OnEnemyKilled?.Invoke();
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity).Play();
            explosionSound.Play();
            Destroy(gameObject);
            CameraShaker.Instance.ShakeOnce(1.5f, 20f, 0.5f, 0.5f);
            PlayerController.hasShot = false;
            


        }
    }




}
