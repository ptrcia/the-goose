using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LanguageClassic : MonoBehaviour
{
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
    [SerializeField] TextMeshProUGUI reload;
    [SerializeField] TextMeshProUGUI exit;
    [SerializeField] TextMeshProUGUI mainmenu;
    [SerializeField] TextMeshProUGUI resume;

    [Header("WinPanel")]
    [SerializeField] TextMeshProUGUI reloadWin;
    [SerializeField] TextMeshProUGUI exitWin;
    [SerializeField] TextMeshProUGUI mainmenuWin;

    [Header("Audio")]
    [SerializeField] TextMeshProUGUI music;
    [SerializeField] TextMeshProUGUI SFX;

    [Header("Others")]
    [SerializeField] TextMeshProUGUI round;
    [SerializeField] TextMeshProUGUI win;

    [SerializeField] TMP_Text textMeshProComponent;  // Referencia a tu componente TextMeshPro
    [SerializeField] TMP_FontAsset otherFont;          // La nueva fuente que quieres usar
    [SerializeField] TMP_FontAsset normalFont;
    void Start()
    {
        // Verifica que los componentes no sean nulos
        if (textMeshProComponent != null && normalFont != null)
        {
            // Cambia la fuente
            textMeshProComponent.font = normalFont;
        }
        else
        {
            Debug.LogError("Asegúrate de que textMeshProComponent y newFont estén asignados.");
        }
    }

    void Update()
    {
        CheckLanguage();
    }

    void CheckLanguage()
    {
        if (PlayerPrefs.GetString("LanguageChosen") == "English")
        {
            textMeshProComponent.font = normalFont;
            //title.font = new Font()
            title.text = "Rules";
            gooseRules.text = "The Goose";
            bridge.text = "The Bridge";
            innRules.text = "The Inn";
            wellRules.text = "The Well";
            labyrinthRules.text = "The Labyrinth";
            dicesRules.text = "The Dices";
            jailRules.text = "The Jail";
            deathRules.text = "The Death";
            gardenRules.text = "The Garden";

            gooseAddicional.text = "If you land on this cell, teleport to the next goose cell and re-roll.";
            bidgeAddicional.text = "If you land on this cell you teleport to the other bridge on the board either in front of you or behind you and re-roll.";
            innAddicional.text = "If you fall in this cell, you lose a turn.";
            wellAddicional.text = "If you land on this cell, you CANNOT play again until another player passes through that cell or two turns were played";
            labyrinthAddicional.text = "If you fall on this cell, you are forced to move back to cell 30.";
            dicesAddicional.text = "If you land on this cell, you teleport to the other die cell on the board either in front of you or behind you and re-roll.";
            jailAddicional.text = "If you fall into this cell, you have to stay two turns without playing.";
            deathAddicional.text = "If you fall in this cell, go back to the start.";
            gardenAddicional.text = "It is necessary to score the right number of points to enter the final cell, in case of exceeding the number of points, you go back as many cells as the number you have exceeded.";

            goose.text = "From goose to goose \r\nI move as I choose";
            bridge.text = "From bidge to bridge\r\n come see if I miss";
            dice.text = "From dice to dice\r\nI slide and get by";

            reload.text = "Restart";
            exit.text = "Exit";
            mainmenu.text = "Main Menu";
            resume.text = "Continue";

            reloadWin.text = "Another one!";
            exitWin.text = "Exit";
            mainmenuWin.text = "Main Menu";

            music.text = "Music";
            SFX.text = "Sound Effects";

            round.text = "New Round!";
            win.text = "You win!";
        }
        else if (PlayerPrefs.GetString("LanguageChosen") == "Spanish")
        {
            textMeshProComponent.font = otherFont;
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

            gooseAddicional.text = "Si caes en esta casilla, te mueves a la siguiente oca y tiras de nuevo.";
            bidgeAddicional.text = "Si caes en esta casilla, te mueves al siguiente puente (esté delante o detrás) y vuelves a tirar.";
            innAddicional.text = "Si caes en esta casilla, pierdes un turno.";
            wellAddicional.text = "Si caes en esta casilla, NO puedes volver a jugar hasta que otro jugador pase por esa casilla o hayan pasado dos turnos";
            labyrinthAddicional.text = "Si caes en esta casilla, te mueves a las casilla 30.";
            dicesAddicional.text = "Si caes en esta casilla, te teletrasportas a la otra casilla de dado (esté delante o detrás) y vuelves a tirar.";
            jailAddicional.text = "Si caes en esra casilla, pierdes dos turnos.";
            deathAddicional.text = "Si caes en esta casilla, vuelves al principio.";
            gardenAddicional.text = "Es necesario sacar el numero exacto para entrar a la casilla final, en el caso de sobrepsasar, retrocedes tantas casillas como número te hayas sobrepasado.";

            goose.text = "De oca a oca \r\nY tiro porque me toca";
            bridge.text = "De puente a puente\r\n y tiro porque me lleva la corriente";
            dice.text = "De dado a dado \r\n y tiro porque me ha tocado";

            reload.text = "Nueva Partida";
            exit.text = "Salir";
            mainmenu.text = "Menú Principal";
            resume.text = "Continuar";

            reloadWin.text = "¡Otra más!";
            exitWin.text = "Salir";
            mainmenuWin.text = "Menú Principal";
            s
            music.text = "Música";
            SFX.text = "Efectos de sonido";

            round.text = "¡Nueva Ronda!";
            win.text = "¡Has ganado!";
        }
    }
}
