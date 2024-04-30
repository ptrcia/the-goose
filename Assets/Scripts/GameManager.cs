using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject pausePanel;


    //[SerializeField] Slider sliderMaster;
    //[SerializeField] AudioMixer audioMixer;

    private void Start()
    {
        //sliderMaster.value = PlayerPrefs.GetFloat("volumeMaster");
        ResumeGame();
        AudioListener.pause = false; //important to say to unity to unpause music

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeInHierarchy)
            {
                pausePanel.SetActive(false);
                //Cursor.lockState = CursorLockMode.Locked;
                ResumeGame();
                AudioListener.pause = false;

            }
            else
            {
                pausePanel.SetActive(true);
                //Cursor.lockState = CursorLockMode.None;
                PauseGame();
                AudioListener.pause = true;
            }
        }
    }
    public void Win()
    {
        Debug.Log("YOU WON");
        PauseGame();
        winPanel.SetActive(true);
        //pausa
        //abrir canvas de final de juego
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
    public void volumeMaster(float volume)
    {
        //audioMixer.SetFloat("volumeMaster", volume);
    }
    public void ReloadScene()
    {
        int actualScene = SceneManager.GetActiveScene().buildIndex;
        AudioListener.pause = true;
        SceneManager.LoadScene(actualScene);
    }

}