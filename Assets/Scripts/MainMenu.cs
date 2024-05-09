using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GetValueDropdown getValueDropdownPlayers;
    [SerializeField] GetValueDropdown getValueDropdownBoards;
    [SerializeField] GetValueDropdown getValueDropdownLanguage;

    [SerializeField] private GameObject startButton;

    string sceneToLoad = "02-Classic";

    private void Update()
    {
        SettingsPlayers();
        SettingsBoard();
        SettingsLanguage();
    }

    public void PlayGame()
    {
        FillScreenButton();
        float delay = 1f;
        Invoke("LoadScene", delay);
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
                //cambiar el tablero y las reglas y supongo que ya la escena, no?
                //Debug.Log("Has selecionado la tabla " + optionBoard);
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
        //CREO QUE COMPROBAR QUQE EATS BIEN ???????????????????????
        switch (optionLanguage)
        {
            case "English":
                //cosas
                //Debug.Log("Has selecionado el idioma " + optionLanguage);
                languageChosen = "English";
                PlayerPrefs.SetString("LanguageChosen", languageChosen);
                break;
            case "Spanish":
                //cosas en español
                //Debug.Log("Has selecionado el idioma " + optionLanguage);
                languageChosen = "Spanish";
                PlayerPrefs.SetString("LanguageChosen", languageChosen);
                break;
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
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
    public void URL() //Unity Method to include URL to click on
    {
        Application.OpenURL("https://ptrcia.github.io/porfolio/");
    }
}
