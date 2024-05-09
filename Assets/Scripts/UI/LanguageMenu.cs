using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LanguageMenu : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI start;
    [SerializeField] TextMeshProUGUI language;
    [SerializeField] TextMeshProUGUI exit;
    [SerializeField] TextMeshProUGUI music;
    [SerializeField] TextMeshProUGUI SFX;
    [SerializeField] TextMeshProUGUI players;
    [SerializeField] TextMeshProUGUI board;
    [SerializeField] TextMeshProUGUI startGame;

    void Update()
    {
        CheckLanguage();
    }

    void CheckLanguage()
    {
        if (PlayerPrefs.GetString("LanguageChosen") == "English")
        {
            //Debug.Log("Se ha elegido el Inglés");
            title.text = "The Game of the Goose";
            start.text = "Start";
            language.text = "Language";
            exit.text = "Exit";
            music.text = "Music";
            SFX.text = "Sound Effects";
            players.text = "Number of players";
            board.text = "Type of board";
            startGame.text = "Let's go!";
        }
        else if (PlayerPrefs.GetString("LanguageChosen") == "Spanish")
        {
            //Debug.Log("Se ha elegido el Español");
            title.text = "El Juego de la Oca";
            start.text = "Empezar";
            language.text = "Idioma";
            exit.text = "Salir";
            music.text = "Música";
            SFX.text = "Efectos de sonido";
            players.text = "Número de jugadores";
            board.text = "Tipo de tablero";
            startGame.text = "¡Allá vamos!";

        }
    }
}
