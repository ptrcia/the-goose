using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class MainMenu : MonoBehaviour
{
    [SerializeField] GetValueDropdown getValueDropdownPlayers;
    [SerializeField] GetValueDropdown getValueDropdownBoards;
    [SerializeField] GetValueDropdown getValueDropdownLanguage;

    [SerializeField] private GameObject startButton;

    string sceneToLoad = "02-Classic";
    [SerializeField] TMP_Dropdown dropdownBoard;
    List<string> options = new List<string> { "Test" };

    [SerializeField] TMP_InputField inputField;
    [SerializeField] TextMeshProUGUI messageCode;

    private void Start()
    {
        Time.timeScale = 1;
        inputField.onEndEdit.AddListener(Code);
    }

    private void Update()
    {
        SettingsPlayers();
        SettingsBoard();
        SettingsLanguage();
    }

    public void PlayGame()
    {
        Debug.Log("Empezando a empezar");
        FillScreenButton();
        float delay = 1f;
        Invoke(nameof(LoadScene), delay);
        //SceneManager.LoadScene("02-Classic");
        //LoadScene();
        Debug.Log("Scene to load: " + sceneToLoad);
    }
    public void Quit()
    {
        Debug.Log("Quitting...");
       Application.Quit();
    }
    void SettingsPlayers()
    {
        string optionPlayers = getValueDropdownPlayers.GetSelectedOption();
        int numberPlayers;
        switch (optionPlayers)
        {
            case "1":
                numberPlayers = 1;
                PlayerPrefs.SetInt("NumberPlayers", numberPlayers);
                break;
            case "2":
                numberPlayers = 2;
                PlayerPrefs.SetInt("NumberPlayers", numberPlayers);
                break;
            case "3":
                numberPlayers = 3;
                PlayerPrefs.SetInt("NumberPlayers", numberPlayers);
                break;
            case "4":
                numberPlayers = 4;
                PlayerPrefs.SetInt("NumberPlayers", numberPlayers);
                break;
        }
    }

    void SettingsBoard()
    {
        string optionBoard = getValueDropdownBoards.GetSelectedOption();
        switch (optionBoard)
        {
            case "Classic":
                sceneToLoad = "02-Classic";
                break;

            case "Test":
                sceneToLoad = "SampleScene";
                break;
        }
    }
    void SettingsLanguage()
    {
        string optionLanguage = getValueDropdownLanguage.GetSelectedOption();
        string languageChosen = "";
        switch (optionLanguage)
        {
            case "English":
                languageChosen = "English";
                PlayerPrefs.SetString("LanguageChosen", languageChosen);
                break;
            case "Spanish":
                languageChosen = "Spanish";
                PlayerPrefs.SetString("LanguageChosen", languageChosen);
                break;
        }
    }

    public void Code(string code)
    {
        switch(code)
        {
            case "Test":
                //dropdownBoard.AddOptions(options);

                if (PlayerPrefs.GetString("LanguageChosen") == "English")
                {
                    messageCode.text = "You unlocked a new board!";
                }
                else if (PlayerPrefs.GetString("LanguageChosen") == "Spanish")
                {
                    messageCode.text = "Has desbloqueado un nuevo tablero!";
                }
                    
                break;
            default:
                if (PlayerPrefs.GetString("LanguageChosen") == "English")
                {
                    messageCode.text = "Wrong Code";
                }
                else if (PlayerPrefs.GetString("LanguageChosen") == "Spanish")
                {
                    messageCode.text = "Código erróneo";
                }
                break;
        }
    }

    void LoadScene()
    {
        Debug.Log("Encima del load");
        SceneManager.LoadScene(sceneToLoad);
        Debug.Log("Debajo del load");
    }

    private void FillScreenButton()
    {
        RectTransform rectTransform = startButton.GetComponent<RectTransform>();
        Vector2 screenSize = new Vector2(Screen.width*5, Screen.height*5);
        if (rectTransform != null)
        {
            rectTransform.DOSizeDelta(screenSize, 2f);
        }
    }
    public void URL(string URL) //Unity Method to include URL to click on
    {
        Application.OpenURL(URL);
    }

}
