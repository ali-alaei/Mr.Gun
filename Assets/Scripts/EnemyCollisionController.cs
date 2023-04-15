using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionController : MonoBehaviour
{

    public static bool isDead;

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
            Destroy(gameObject);
            PlayerController.hasShot = false;
            


        }
    }




}
