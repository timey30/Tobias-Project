﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenueUI;
    public GameObject sett;
    public static bool GameIsPaused = false;
    private GameObject script;


    void Update()
    {
        script = GameObject.FindWithTag("Player");
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                pauseMenueUI.SetActive(false);
                script.GetComponent<Movement>().enabled = true;
                Time.timeScale = 1f;
                GameIsPaused = false;
            }
            else
            {
                pauseMenueUI.SetActive(true);
                script.GetComponent<Movement>().enabled = false;
                Time.timeScale = 0f;
                GameIsPaused = true;
            }
        }

    }

    public void Resume()
    {
        pauseMenueUI.SetActive(false);
        script.GetComponent<Movement>().enabled = true;
        Time.timeScale = 1f;
        GameIsPaused = false;
        FindObjectOfType<AudioManager>().Play("PauseClose");
    }

    public void Settings()
    {
        sett.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void SettClose()
    {
        sett.SetActive(false);
        Time.timeScale = 0f;

    }

    public void Pause()
    {
        pauseMenueUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        FindObjectOfType<AudioManager>().Play("PauseOpen");
    }

    public void Click()
    {
        FindObjectOfType<AudioManager>().Play("Button");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Vagrant Project....");
    }
}
