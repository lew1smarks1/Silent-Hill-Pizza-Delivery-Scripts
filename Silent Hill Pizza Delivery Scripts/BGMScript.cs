using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour
{
    private int startingPitch = 1;
    private int timeToIncrease = 600;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = startingPitch;
        audioSource.PlayDelayed(1.45f);//plays music 1.45seconds after it starts, hardcoded number could be replaced by private variable
    }
    void Update()
    {
        if(audioSource.pitch<1.5)//increases the pitch slowly to a limit, hardcoded again
        {
            audioSource.pitch += Time.deltaTime*startingPitch/timeToIncrease;
        }
    }
}
