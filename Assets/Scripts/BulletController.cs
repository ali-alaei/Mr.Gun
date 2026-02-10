using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public enum ShooterType
    {
        Player,
        Enemy
    }
    [SerializeField]private float lifetime = 2f;
    private ShooterType shooter;
    private bool shotHasResolved = false;
    
    public void SetShooterType(ShooterType shooter)
    {
        this.shooter = shooter;
    }
    public ShooterType GetShooterType()
    {
        return this.shooter;
    }
    // add a constructor, pass the game object which is the owner and when it collides ask it who is your owner
    

    void Start()
    {
        Destroy(gameObject, lifetime); // destroy bullet after lifetime seconds
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!shotHasResolved && shooter == ShooterType.Player && 
        collision.gameObject.CompareTag("MissZone"))
        {
            //miss
            Actions.OnPlayerShotResolved?.Invoke(false);
            this.shotHasResolved = true;
            Destroy(gameObject);

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!shotHasResolved && shooter == ShooterType.Player && 
        collision.gameObject.CompareTag("Enemy"))
        {
            //hit
            Actions.OnPlayerShotResolved?.Invoke(true);
            this.shotHasResolved = true;
            Destroy(gameObject);
            return;
        }

        if (collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject); // destroy bullet on collision
        }
    }


}
