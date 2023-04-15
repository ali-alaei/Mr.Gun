using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // add a constructor, pass the game object which is the owner and when it collides ask it who is your owner
    public float lifetime = 2f;

    void Start()
    {
        Destroy(gameObject, lifetime); // destroy bullet after lifetime seconds
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("Enemy"))
        {

            Destroy(gameObject); // destroy bullet on collision
        }
    }


}
