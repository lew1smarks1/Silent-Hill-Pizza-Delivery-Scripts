using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Vehicle"))
        {
            Pickup();
        }
    }
    private void Awake()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }
    private void Pickup()//when pizza is picked up, play a sound, turn on the timer and destroy it
    {
        audioSource.Play();
        PizzaTimer.GetInstance().TurnOn();
        Destroy(gameObject);
    }
}
