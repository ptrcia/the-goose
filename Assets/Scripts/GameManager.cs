
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject pausePanel;

    private void Start()
    {
        ResumeGame();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (pausePanel.activeInHierarchy)
            {
                pausePanel.SetActive(false);
                ResumeGame();
            }
            else
            {
                pausePanel.SetActive(true);
                PauseGame();
            }
        }
    }
    public void Win()
    {
        Debug.Log("YOU WON");
        PauseGame();
        winPanel.SetActive(true);
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        if(pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(false);
        }
        else if (winPanel.activeInHierarchy)
        {
            winPanel.SetActive(false);
        }
    }

    public void ReloadScene()
    {
        int actualScene = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
        AudioListener.pause = true;
        SceneManager.LoadScene(actualScene);
    }

    public void URL() //Unity Method to include URL to click on
    {
        Application.OpenURL("https://ptrcia.github.io/porfolio/");
    }
}