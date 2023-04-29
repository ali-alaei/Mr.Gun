using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrailSound : MonoBehaviour
{
    
    private AudioSource trailSound;

    void Start()
    {
        trailSound = GetComponent<AudioSource>();
        
    }

    void OnEnable()
    {
        Actions.OnPlayerMove += PlayTrailSound;

    }

    private void OnDisable()
    {
        Actions.OnPlayerMove -= PlayTrailSound;
    }

    void PlayTrailSound()
    {

        trailSound.Play();


    }
}
