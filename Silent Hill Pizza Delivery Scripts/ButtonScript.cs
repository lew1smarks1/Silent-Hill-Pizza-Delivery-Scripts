using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    private AudioSource audioSource;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayDelayed(1.4f);
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart ()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainGame");
    }
}
