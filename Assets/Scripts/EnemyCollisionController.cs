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
            //gameObject.SetActive(false);
            //gameObject.transform.position = new Vector3(5f, 4.88f, 0f);
            //gameObject.SetActive(true);
            //Debug.Log("Enemy got shot");
            isDead = true;
            Destroy(gameObject);
            PlayerController.hasShot = false;
            


        }
    }




}
