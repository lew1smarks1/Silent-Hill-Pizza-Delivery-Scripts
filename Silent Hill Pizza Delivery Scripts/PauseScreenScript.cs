using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenScript : MonoBehaviour
{
    public static bool isPaused = false;
    [SerializeField]
    private GameObject pauseMenuUI;
    private AudioSource audioSource;

    public static bool afterStart=false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && afterStart)//escape to pause the game, while paused escape to resume
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public static void NoPause()
    {
        afterStart = false;
    }

    IEnumerator AllowPause()//lets you pause the game after the game has started, not while waiting to start
    {
        yield return new WaitForSeconds(0.1f);
        afterStart = true;
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        afterStart = false;
        StartCoroutine(AllowPause());
    }
    public void Resume()//resumes the game and gets rid of the pausemenuUI
    {
        audioSource.Play();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()//pauses the game and shows the pausemenuUI
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()//loads the main menu
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused=false;
        audioSource.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()//quits the game
    {
        audioSource.Play();
        Application.Quit();
    }
}
