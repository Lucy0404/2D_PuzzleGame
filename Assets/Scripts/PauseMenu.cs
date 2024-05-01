using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pause_Menu;
    private AudioManager audioManager;
    [SerializeField] public GameObject myPanel;
    public WinScript winScript;
    public GameObject pauseButton;
    public GameObject soundButton;
    public GameObject lvl;
    public GameObject infoButton;


    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        winScript = FindObjectOfType<WinScript>();
        winScript.Restart();
    }

    public void Pause()
    {
        myPanel.SetActive(false);
        pauseButton.SetActive(false);
        pause_Menu.SetActive(true);
        Time.timeScale = 0f;
        audioManager.PauseMusic();
        soundButton.SetActive(false);
        lvl.SetActive(false);
        infoButton.SetActive(false);
    }

    public void Resume()
    {
        pause_Menu.SetActive(false);
        myPanel.SetActive(true);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        audioManager.ResumeMusic();
        soundButton.SetActive(true);
        lvl.SetActive(true);
        infoButton.SetActive(true);
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void Restart()
    {
        winScript.Restart(); 
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void NextLevel()
    {
        winScript.Restart();
        SceneManager.LoadScene("Level 2");
    }

}
