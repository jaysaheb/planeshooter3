using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        pauseButton.SetActive(false);
    }
    public void Quitgame()
    {
        Application.Quit();
    }
}
