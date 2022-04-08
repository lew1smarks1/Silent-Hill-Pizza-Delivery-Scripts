using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMove : MonoBehaviour
{
    [SerializeField]
    private float speed=15f;
    [SerializeField]
    private float turnSpeed=80f;
    [SerializeField]
    private float gravityScale = 0.25f;
    private GameObject deathScreen;
    private GameObject startScreen;
    private GameObject cameraTransform3;
    private AudioSource myAudioSource;
    private bool isDead = false;
    private bool soundPlayed = false;
    private bool soundPlayed2 = false;
    private bool onRoad = true;
    private bool fall = false;
    private static VehicleMove instance;

    public static VehicleMove GetInstance()
    {
        return instance;
    }
    public bool GetDeath()
    {
        return isDead;
    }

    IEnumerator speedUp()//increases speed to a limit
    {
        while (speed < 55f)
        {
            yield return new WaitForSeconds(1f);
            speed += 0.5f;
        }
    }

    IEnumerator death()
    {
        if (isDead)
        {
            if(CameraScript.GetInstance().GetCamMode()==1)//takes player out of 1st person view
            {
                CameraScript.GetInstance().SetCamMode();
            }
            cameraTransform3.transform.parent = null;//detaches camera from the vehicle
            turnSpeed = 0f;
            PauseScreenScript.NoPause();//stops player from being able to pause the game
            if (!soundPlayed2)
            {
                SoundManager.PlaySound(SoundManager.Sound.Fall);//plays fall sound
                soundPlayed2 = true;
            }
            yield return new WaitForSeconds(2f);
            if (!soundPlayed)//the sound was being played multiple times, so I made a bool to limit it to play only once
            {
                SoundManager.PlaySound(SoundManager.Sound.Lose);
                soundPlayed = true;
            }
            deathScreen.SetActive(true);//show deathscreen
            Score.TrySetNewHighscore(Score.GetInstance().GetScore());//sets the highscore
            yield return new WaitForSeconds(2f);
            Time.timeScale = 0;//pauses the game
        }
    }

    IEnumerator Fall()//if you're off the road for long enough the car will slow down so that you don't speed through deathplanes
    {
        yield return new WaitForSeconds(2f);
        if(!onRoad)
        {
            fall=true;
        }
    }

    private void OnCollisionEnter(Collision collision)//play a sound when you collide with an obstacle
    {
        if (collision.gameObject.CompareTag("Obstacle"))//haven't used tags made out of strings, maybe should next time
        {
            myAudioSource.Play();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeathPlane"))//die when you hit a deathplane
        {
            isDead = true;
        }
    }

    private void Awake()//a lot of initialization
    {
        isDead = false;
        instance = this;
        deathScreen = GameObject.Find("Canvas2");//no tags again
        startScreen = GameObject.Find("StartScreen");
        cameraTransform3 = GameObject.Find("ThirdCam");
        myAudioSource = gameObject.GetComponent<AudioSource>();
        turnSpeed = 80f;
        soundPlayed2 = false;
        soundPlayed = false;
        onRoad = true;
        deathScreen.SetActive(false);
        startScreen.SetActive(true);
        Time.timeScale = 0;
    }

    private void Start()
    {
        StartCoroutine(speedUp());
        SoundManager.PlaySound(SoundManager.Sound.StartScreen);//play start sound "StartScreen", bad naming
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Road"))
        {
            onRoad = false;
            StartCoroutine(Fall());//slows you down if you're off the road for long enough
        }
    }

    private void OnCollisionStay(Collision collision)//makes sure that you're considered on the road when you're colliding with it
    {
        if (collision.gameObject.CompareTag("Road"))
        {
            onRoad = true;
        }
    }
    void Update()
    {
        StartCoroutine(death());//should only be called when collided
        transform.Rotate(Vector3.up, Input.GetAxisRaw("Horizontal") * Time.deltaTime * turnSpeed);//rotation control
        transform.Translate(Vector3.forward * Time.deltaTime * speed + Physics.gravity*gravityScale*Time.deltaTime);//forward movement
        if (Input.GetAxisRaw("Horizontal") != 0 && !PauseScreenScript.isPaused)//move to start the game
        {
            Time.timeScale = 1;
            startScreen.SetActive(false);
        }
        if (fall)//slows down the car when it is falling so that it actually collides with deathplanes
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }
    }

}
