using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject controlPanel;



    
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

   
    public void Pause()
    {  
        Time.timeScale = 0;
        menuButton.SetActive(true);
        restartButton.SetActive(true);
        resumeButton.SetActive(true);
        pauseButton.SetActive(false);
        controlPanel.SetActive(false);

    }
    public void Resume()
    {
        
        Time.timeScale = 1;
        menuButton.SetActive(false);
        restartButton.SetActive(false);
        resumeButton.SetActive(false);
        pauseButton.SetActive(true);
        controlPanel.SetActive(true);


    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

   
}
