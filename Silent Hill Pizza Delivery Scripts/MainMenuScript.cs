using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private GameObject mainMenuButtons;
    [SerializeField]
    private GameObject settingsButtons;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        settingsButtons.SetActive(false);
    }

    public void NewGame()//play button loads main game scene
    {
        audioSource.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene("MainGame");
    }

    public void Settings()//activates settings menu while disabling the other options
    {
        audioSource.Play();
        mainMenuButtons.SetActive(false);
        settingsButtons.SetActive(true);
    }

    public void SettingsOff()//returns from settings menu to the main menu
    {
        audioSource.Play();
        mainMenuButtons.SetActive(true);
        settingsButtons.SetActive(false);
    }

    public void QuitGame()//quit game button
    {
        audioSource.Play();
        Application.Quit();
    }

}
