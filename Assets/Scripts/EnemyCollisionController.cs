using EZCameraShake;
using UnityEngine;

public class EnemyCollisionController : MonoBehaviour
{
    
    [SerializeField] ParticleSystem explosionPrefab;
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Actions.OnEnemyKilled?.Invoke();
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity).Play();
            
            Destroy(gameObject);
            CameraShaker.Instance.ShakeOnce(1.5f, 20f, 0.5f, 0.5f);

        }
    }




}
