using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public GameObject optionsPanel;
    public GameObject pausePanel;
    public void PlayeGame()
    {
        Debug.Log("Play Game");
        SceneManager.LoadScene(1); //Oyun ekraný
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Options()
    {
        optionsPanel.SetActive(true);
        Debug.Log("Options");
    }
    public void CloseOption()
    {
        optionsPanel.SetActive(false);

    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }
    public void Continuegame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
}
