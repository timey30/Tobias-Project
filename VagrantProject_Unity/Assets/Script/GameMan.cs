using UnityEngine.SceneManagement;
using UnityEngine;
public class GameMan : MonoBehaviour
{
    private GameObject script;

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Quit");
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
        
    }

    public void EndGame()
    {
        Debug.Log("GameOver");
    }


}
