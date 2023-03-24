using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public bool isTurnComplete; 
    public bool isAlive;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            isAlive = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isTurnComplete = false;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
