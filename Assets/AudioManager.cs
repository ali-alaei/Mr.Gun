using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource explosionSound;
    void Start()
    {
        explosionSound = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Actions.OnEnemyKilled += PlayExplosionSound;
        Actions.OnPlayerKilled += PlayExplosionSound;
    }

    private void OnDisable()
    {
        Actions.OnEnemyKilled -= PlayExplosionSound;
        Actions.OnPlayerKilled -= PlayExplosionSound;
    }

    void PlayExplosionSound()
    {


        explosionSound.Play();

    }

}
