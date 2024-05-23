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
    //[SerializeField] TextMeshProUGUI languageOptions;
    [SerializeField] TextMeshProUGUI exit;
    [SerializeField] TextMeshProUGUI master;
    [SerializeField] TextMeshProUGUI music;
    [SerializeField] TextMeshProUGUI SFX;
    [SerializeField] TextMeshProUGUI players;
    [SerializeField] TextMeshProUGUI board;
    [SerializeField] TextMeshProUGUI startGame;
    [SerializeField] TextMeshProUGUI options;

    [SerializeField] TextMeshProUGUI code;
    [SerializeField] TextMeshProUGUI introduction;

    [Header("Fonts")]
    [SerializeField] TMP_FontAsset japaneseFont;          // La nueva fuente que quieres usar
    [SerializeField] TMP_FontAsset basicFont;
    [SerializeField] TMP_FontAsset basicAlternativeFont;
    [SerializeField] TMP_FontAsset japaneseAlternativeFont;


    void Start()
    {
        UpdateLanguageAndFont();
    }

    void Update()
    {
        UpdateLanguageAndFont();
    }
    void UpdateLanguageAndFont()
    {
        string language = PlayerPrefs.GetString("LanguageChosen");

        if (language == "Japanese") 
        {
            ApplyFontToAllTextComponents(japaneseFont);
            ApplyFontToAlternativeTextComponents(japaneseAlternativeFont);
        }
        else
        {
            ApplyFontToAllTextComponents(basicFont);
            ApplyFontToAlternativeTextComponents(basicAlternativeFont);
        }

        if (language == "English")
        {
            SetEnglishText();
        }
        else if (language == "Spanish")
        {
            SetSpanishText();
        }
        else if (language == "Japanese")
        {
            SetJapaneseText();
        }
    }

    void ApplyFontToAllTextComponents(TMP_FontAsset font)
    {
        TextMeshProUGUI[] textComponents = {
            title, start, language, exit, master, music, SFX, players, board, startGame, options, code,
        };

        foreach (var textComponent in textComponents)
        {
            if (textComponent != null)
            {
                textComponent.font = font;
            }
        }
    }
    void ApplyFontToAlternativeTextComponents(TMP_FontAsset font)
    {
        TextMeshProUGUI[] textComponents = {
            introduction
        };

        foreach (var textComponent in textComponents)
        {
            if (textComponent != null)
            {
                textComponent.font = font;
            }
        }
    }
    void SetEnglishText()
    {
        title.text = "The Game of the Goose";
        start.text = "Start";
        language.text = "Language";
        //languageOptions.text = "";
        exit.text = "Exit";
        master.text = "Master";
        music.text = "Music";
        SFX.text = "Sound Effects";
        players.text = "Number of players";
        board.text = "Type of board";
        startGame.text = "Let's go!";
        options.text = "Options";

        code.text = "Code: ";
        introduction.text = "Hi! \r\nThis game is in development. You will find bugs and unfinished things. \r\nI will keep updating it and I aim to finish it by the end of august 2024.\r\nHere you can follow the updates----->\r\nHere you can write me if you find any bug.";
    }

    void SetSpanishText()
    {
        title.text = "El Juego de la Oca";
        start.text = "Empezar";
        language.text = "Idioma";
        exit.text = "Salir";
        master.text = "Master";
        music.text = "Música";
        SFX.text = "Efectos de sonido";
        players.text = "Número de jugadores";
        board.text = "Tipo de tablero";
        startGame.text = "¡Allá vamos!";
        options.text = "Opciones";

        code.text = "Código: ";
        introduction.text = "¡Hola!\r\nEste juego está en desarrollo. Os encontraréis fallos y cosas inacabadas. Iré actualizándolo y pretendo acabarlo para final de agosto 2024.\r\nAquí podéis seguir las actualizaciones->\r\nAquí me podéis escribir si encontrais cualquier error.";
    }
    void SetJapaneseText()
    {
        title.text = "ガチョウのゲーム";
        start.text = "スタート";
        language.text = "言語";
        exit.text = "閉じる";
        master.text = "ー般オーディオ";
        music.text = "音楽";
        SFX.text = "効果音";
        players.text = "プレイヤーの数";
        board.text = "ボードの種類";
        startGame.text = "行こう！";
        options.text = "オプション";

        code.text = "コード: ";
        introduction.text = "こんにちは！\r\n このゲームは開発中です。バグや未完成の部分が見つかるでしょう。更新を続け、年末までに完成を目指しています。\r\nプデートはこちらから→\r\nエラーを見つけたら書き込みしてください.";
    }
}