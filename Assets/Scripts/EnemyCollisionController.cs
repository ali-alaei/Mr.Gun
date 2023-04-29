using System.Collections;
using System.Collections.Generic;
using EZCameraShake;
using UnityEngine;

public class EnemyCollisionController : MonoBehaviour
{
    public static bool isDead;
    [SerializeField] ParticleSystem explosionPrefab;

    private void Start()
    {
        Debug.Log("EnemyCollision started");
        isDead = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
           
            isDead = true;
            Actions.OnEnemyKilled?.Invoke();
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity).Play();
            CameraShaker.Instance.ShakeOnce(1.5f, 20f, 0.5f, 0.5f);
            Destroy(gameObject);
            PlayerController.hasShot = false;
            


        }
    }




}
