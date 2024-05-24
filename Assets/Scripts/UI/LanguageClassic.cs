using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LanguageClassic : MonoBehaviour
{
    public static LanguageClassic instance;

    [Header("Rules")]
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI gooseRules;
    [SerializeField] TextMeshProUGUI bridgeRules;
    [SerializeField] TextMeshProUGUI innRules;
    [SerializeField] TextMeshProUGUI wellRules;
    [SerializeField] TextMeshProUGUI labyrinthRules;
    [SerializeField] TextMeshProUGUI dicesRules;
    [SerializeField] TextMeshProUGUI jailRules;
    [SerializeField] TextMeshProUGUI deathRules;
    [SerializeField] TextMeshProUGUI gardenRules;

    [SerializeField] TextMeshProUGUI gooseAddicional;
    [SerializeField] TextMeshProUGUI bidgeAddicional;
    [SerializeField] TextMeshProUGUI innAddicional;
    [SerializeField] TextMeshProUGUI wellAddicional;
    [SerializeField] TextMeshProUGUI labyrinthAddicional;
    [SerializeField] TextMeshProUGUI dicesAddicional;
    [SerializeField] TextMeshProUGUI jailAddicional;
    [SerializeField] TextMeshProUGUI deathAddicional;
    [SerializeField] TextMeshProUGUI gardenAddicional;

    [Header("Rhymes")]
    [SerializeField] TextMeshProUGUI goose;
    [SerializeField] TextMeshProUGUI bridge;
    [SerializeField] TextMeshProUGUI dice;

    [Header("Pause Menu")]
    [SerializeField] TextMeshProUGUI pause;
    [SerializeField] TextMeshProUGUI reload;
    [SerializeField] TextMeshProUGUI exit;
    [SerializeField] TextMeshProUGUI mainmenu;
    [SerializeField] TextMeshProUGUI resume;

    [Header("WinPanel")]
    [SerializeField] TextMeshProUGUI textWin;
    [SerializeField] TextMeshProUGUI reloadWin;
    [SerializeField] TextMeshProUGUI exitWin;
    [SerializeField] TextMeshProUGUI mainmenuWin;

    [Header("Audio")]
    [SerializeField] TextMeshProUGUI master;
    [SerializeField] TextMeshProUGUI music;
    [SerializeField] TextMeshProUGUI SFX;

    [Header("Others")]
    [SerializeField] TextMeshProUGUI round;
    [SerializeField] TextMeshProUGUI win;

    [Header("Fonts")]
    [SerializeField] public TMP_FontAsset japaneseFont;
    [SerializeField] public TMP_FontAsset basicFont;
    [SerializeField] TMP_FontAsset basicAlternativeFont;
    [SerializeField] public TMP_FontAsset japaneseAlternativeFont;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
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

        // Actualizar textos según el idioma
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
            title, gooseRules, bridgeRules, innRules, wellRules, labyrinthRules, dicesRules, jailRules, deathRules, gardenRules,  
            goose, bridge, dice,
            reload, exit, mainmenu, resume,
            reloadWin, exitWin, mainmenuWin,
            music, SFX,
            round, win
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
            gooseAddicional, bidgeAddicional, innAddicional, wellAddicional, labyrinthAddicional, dicesAddicional, jailAddicional, deathAddicional, gardenAddicional,
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
        title.text = "Rules";
        gooseRules.text = "The Goose";
        bridgeRules.text = "The Bridge";
        innRules.text = "The Inn";
        wellRules.text = "The Well";
        labyrinthRules.text = "The Labyrinth";
        dicesRules.text = "The Dices";
        jailRules.text = "The Jail";
        deathRules.text = "The Death";
        gardenRules.text = "The Garden";

        gooseAddicional.text = "Upon landing on this goose space, advance to the next one and roll again.";
        bidgeAddicional.text = "When you land on this bridge space, move your token to the other bridge and roll again.";
        innAddicional.text = "Arriving at this inn space, lose a turn.";
        wellAddicional.text = "If you fall into this well space, you cannot play until another player passes by or two turns have passed.";
        labyrinthAddicional.text = "Falling into this labyrinth space, move back to square 30.";
        dicesAddicional.text = "Landing on this dice space, move to the other dice and roll again.";
        jailAddicional.text = "Reaching this jail space, lose two turns.";
        deathAddicional.text = "Falling into this skull space, return to the start.";
        gardenAddicional.text = "It is necessary to score the right number of points to enter the final cell, in case of exceeding the number of points, you go back as many cells as the number you have exceeded.";

        goose.text = "From goose to goose \r\nI move as I choose";
        bridge.text = "From bidge to bridge\r\n come see if I miss";
        dice.text = "From dice to dice\r\nI slide and get by";

        pause.text = "Pause";
        reload.text = "Restart";
        exit.text = "Exit";
        mainmenu.text = "Main Menu";
        resume.text = "Continue";

        //textWin.text = GameManager.instance.winnerName + " won!";
        textWin.text = " You Won!";
        reloadWin.text = "Another one!";
        exitWin.text = "Exit";
        mainmenuWin.text = "Main Menu";

        master.text = "Master";
        music.text = "Music";
        SFX.text = "Sound Effects";

        round.text = "New Round!";
        win.text = "You win!";
    }

    void SetSpanishText()
    {
        title.text = "Reglas";
        gooseRules.text = "La Oca";
        bridgeRules.text = "El Puente";
        innRules.text = "La Posada";
        wellRules.text = "El Pozo";
        labyrinthRules.text = "El Laberinto";
        dicesRules.text = "Los Dados";
        jailRules.text = "La Cárcel";
        deathRules.text = "La Calavera";
        gardenRules.text = "El Jardín";

        gooseAddicional.text = "Al aterrizar en esta oca, avanza a la próxima y lanza de nuevo.";
        bidgeAddicional.text = "Al caer en este puente, transporta tu ficha al otro puente y vuelve a lanzar.";
        innAddicional.text = "Si llegas a esta posada, pierdes un turno.";
        wellAddicional.text = "Cayendo en este pozo, no puedes jugar hasta que otro jugador pase por aquí o pasen dos turnos.";
        labyrinthAddicional.text = "Al caer en este laberinto, debes retroceder hasta la casilla 30.";
        dicesAddicional.text = "Cayendo en este dado, muévete al otro dado y lanza de nuevo.";
        jailAddicional.text = "Al llegar a esta cárcel, pierdes dos turnos.";
        deathAddicional.text = "Cayendo en esta calavera, regresas al inicio.";
        gardenAddicional.text = "Es necesario sacar el numero exacto para entrar a la casilla final, en el caso de sobrepsasar, retrocedes tantas casillas como número te hayas sobrepasado.";

        goose.text = "De oca a oca \r\nY tiro porque me toca";
        bridge.text = "De puente a puente\r\n y tiro porque me lleva la corriente";
        dice.text = "De dado a dado \r\n y tiro porque me ha tocado";

        pause.text = "Pausa";
        reload.text = "Nueva Partida";
        exit.text = "Salir";
        mainmenu.text = "Menú Principal";
        resume.text = "Continuar";

        //textWin.text = GameManager.instance.winnerName + " ganó!";
        textWin.text =" Has ganado!";

        reloadWin.text = "¡Otra más!";
        exitWin.text = "Salir";
        mainmenuWin.text = "Menú Principal";

        master.text = "Master";
        music.text = "Música";
        SFX.text = "Efectos de sonido";

        round.text = "¡Nueva Ronda!";
        win.text = "¡Has ganado!";
    }

    void SetJapaneseText()
    {
        title.text = "ルール";
        gooseRules.text = "ガチョウ";
        bridgeRules.text = "橋";
        innRules.text = "宿屋";
        wellRules.text = "井戸";
        labyrinthRules.text = "迷宮";
        dicesRules.text = "サイコロ";
        jailRules.text = "刑務所";
        deathRules.text = "死";
        gardenRules.text = "庭";

        gooseAddicional.text = "ガチョウのマスに着陸すると、次のマスに進んでからもう一度振ってください。";
        bidgeAddicional.text = "橋のマスに到達すると、トークンをもう一つの橋に移動させてからもう一度振ってください。";
        innAddicional.text = "宿のマスに到着すると、1ターン休みます。";
        wellAddicional.text = "井戸のマスに落ちた場合、他のプレイヤーが通過するか、2ターンが経過するまでプレイできません。";
        labyrinthAddicional.text = "迷路のマスに落ちた場合、30マスに戻ります。";
        dicesAddicional.text = "ダイスのマスに着陸すると、他のダイスに移動してからもう一度振ってください。";
        jailAddicional.text = "牢獄のマスに到達すると、2ターン休みます。";
        deathAddicional.text = "骸骨のマスに落ちた場合、スタートに戻ります。";
        gardenAddicional.text = "最終マスに入るためには正確な数を出す必要があります。数が超過した場合、その数だけ戻ります。";

        goose.text = "ガチョウからガチョウへ \r\n 私は好きなように動きます";
        bridge.text = "橋から橋へ\r\n 見に来てください、私が外すかどうか";
        dice.text = "サイコロからサイコロへ\r\n 滑っていきます";

        pause.text = "休止";
        reload.text = "再起動";
        exit.text = "終了";
        mainmenu.text = "メインメニュー";
        resume.text = "続ける";

        //textWin.text = GameManager.instance.winnerName + " が勝ちました!";
        textWin.text = " が勝ちました!";
        reloadWin.text = "もう一度！";
        exitWin.text = "終了";
        mainmenuWin.text = "メインメニュー";

        master.text = "ー般オーディオ";
        music.text = "音楽";
        SFX.text = "効果音";

        round.text = "新しいラウンド！";
        win.text = "あなたの勝ち！";
    }
}