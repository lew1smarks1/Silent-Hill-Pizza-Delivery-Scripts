using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField]
    private float bounceForce = 50f;
    private Rigidbody myBody;
    private bool isHit = false;
    private AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myBody = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)//if obstacles hit the deathplane, they're destroyed
    {
        if (other.gameObject.CompareTag("DeathPlane"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)//if obstacles are hit by the car they fly forwards and increment the score
    {
        if (collision.gameObject.CompareTag("Vehicle"))
        {
            Score.GetInstance().ScoreUp();
            myBody.AddForce(collision.transform.forward*bounceForce, ForceMode.Impulse);
            isHit = true;

        }
        //collision combo
        if (collision.gameObject.CompareTag("Obstacle") && isHit)//if obstacles hit another obstacle after being hit by the vehicle, increment the score
        {
            myAudioSource.Play();
            Score.GetInstance().ScoreUp();
        }

    }

}
