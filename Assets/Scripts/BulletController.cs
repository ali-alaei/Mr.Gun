using UnityEngine;

public class BulletController : MonoBehaviour
{
    public enum ShooterType
    {
        Player,
        Enemy
    }
    private const float lifetime = 5.0f;
    private ShooterType shooter;
    private bool shotHasResolved = false;
    
    public void SetShooterType(ShooterType shooter)
    {
        this.shooter = shooter;
    }


    void Start()
    {
        Invoke(nameof(HandleLifetimeFallback), lifetime);
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

    private void HandleLifetimeFallback()
    {
        if (!shotHasResolved && shooter == ShooterType.Player)
        {
            shotHasResolved = true;
            Actions.OnPlayerShotResolved?.Invoke(false);    
        }
        Destroy(gameObject);
    }


}
