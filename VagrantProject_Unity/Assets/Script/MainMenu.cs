using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{   
    
    public void PlayGame()
    {
        
        SceneManager.LoadScene("LevelSelect");
    }

    public void LeaveGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void Level1()
    {
        FindObjectOfType<AudioManager>().Stop("MenuMusic");
        FindObjectOfType<AudioManager>().Play("GameMusic");
        FindObjectOfType<LevelLoader>().LoadLevel("Game");

    }

}
