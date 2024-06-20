
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject winPanel;
    [SerializeField] TextMeshProUGUI winText;
    public GameObject pausePanel;
    public string winnerName= "hola";

    [Header("Audio")]
    [SerializeField] AudioClip audioClipWin;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
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
    public void Win(PlayerMovement winner)
    {
        winnerName = winner.playerID;

        winText.text = winnerName + " won!";
        Debug.Log(winText.text);

        PauseGame();
        AudioManager.instance.PlaySound(audioClipWin);
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
}