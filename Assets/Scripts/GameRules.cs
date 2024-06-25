using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameRules : MonoBehaviour
{
    GameManager gameManager;
    TurnManager turnManager;
    GameManagerUI gameManagerUI;

    int firstBridge = 5;
    int secondBridge = 11;

    int firstDice = 25;
    int secondDice = 52;
    int finalCell = 62;

    public GameObject diceRime;
    public GameObject gooseRime;

    [Header("Well Rule")]
    int playerInWellRemainingTurns = 0;
    PlayerMovement playerInWell = null;

    [Header("Audio")]
    [SerializeField] AudioClip audioClipBridge;
    [SerializeField] AudioClip audioClipDeath;
    [SerializeField] AudioClip audioClipGoose;
    [SerializeField] AudioClip audioClipJail;
    [SerializeField] AudioClip audioClipDice;
    [SerializeField] AudioClip audioClipWell;
    [SerializeField] AudioClip audioClipLab;
    [SerializeField] AudioClip audioClipInnPeople;
    [SerializeField] AudioClip audioClipInnOpen;
    [SerializeField] AudioClip audioClipInnClose;

    private void CheckGameObjects()
    {
        gameManager = GameObject.
            FindGameObjectWithTag("GameManager").
            GetComponent<GameManager>();
        turnManager = GameObject.FindGameObjectWithTag("TurnManager").
            GetComponent<TurnManager>();
        gameManagerUI = GameObject.
            FindGameObjectWithTag("GameManagerUI").
            GetComponent<GameManagerUI>();
    }

    public void CheckSpecialCell(PlayerMovement _playerMovement, GameObject player)
    {
        CheckGameObjects();

        switch (_playerMovement.currentCell)
        {
            case 4 or 8 or 13 or 17 or 22 or 26 or 31 or 35 or
               40 or 44 or 49 or 53 or 58:
                Debug.Log("Oca");
                Goose(_playerMovement, player);
                break;
            case 5 or 11:
                Debug.Log("Puente");
                Bridge(_playerMovement, player);
                break;
            case 18:
                Debug.Log("Posada");
                Inn(_playerMovement);
                break;
            case 30:
                Debug.Log("Pozo");
                Well(_playerMovement);
                break;
            case 41:
                Debug.Log("Laberinto");
                Labyrinth(_playerMovement, player);
                break;
            case 25 or 52:
                Debug.Log("Dados");
                Dices(_playerMovement, player);
                break;
            case 51:
                Debug.Log("Carcel");
                Jail(_playerMovement);
                break;
            case 57:
                Debug.Log("Calavera");
                Death(_playerMovement, player);
                break;
            case 62:
                Debug.Log("Final");
                Final(_playerMovement);
                break;
            case > 62:
                Debug.Log("Jardín");
                //Garden(_playerMovement, player);
                StartCoroutine(GardenBackwards(_playerMovement, player));
                //aqui no me funcionada el nameof
                break;
            default: break;
        }
        

    }

    private void Goose(PlayerMovement _playerMovement, GameObject player)
    {
        Dictionary<int, int> cellOcaTransitions = new Dictionary<int, int>()
            {
                { 4, 8 },
                { 8, 13 },
                { 13, 17 },
                { 17, 22 },
                { 22, 26 },
                { 26, 31 },
                { 31, 35 },
                { 35, 40 },
                { 40, 44 },
                { 44, 49 },
                { 49, 53 },
                { 53, 58 }
            };

        if (cellOcaTransitions.ContainsKey(_playerMovement.currentCell))
        {
            gameManagerUI.StartAnimatingGooseRhymes();
            int destinationCell = cellOcaTransitions[_playerMovement.currentCell];
            AudioManager.instance.PlaySound(audioClipGoose);

            _playerMovement.currentCell = destinationCell;
            player.transform.position = CellManager.instance.cells[destinationCell].position;
            turnManager.nextTurnPlayer = false;
        }
        else if (_playerMovement.currentCell == 58)
        {
            player.transform.position = CellManager.instance.cells[finalCell].position;
            Final(_playerMovement);
        }
    }
    private void Bridge(PlayerMovement _playerMovement, GameObject player)
    {
        AudioManager.instance.PlaySound(audioClipBridge);
        gameManagerUI.StartAnimatingBridgeRhymes();
        if (_playerMovement.currentCell == firstBridge)
        {
            _playerMovement.currentCell = secondBridge;
            player.transform.position = CellManager.instance.cells[_playerMovement.currentCell].position;
            turnManager.nextTurnPlayer = false;
        }
        else if (_playerMovement.currentCell == secondBridge)
        {
            _playerMovement.currentCell = firstBridge;
            player.transform.position = CellManager.instance.cells[_playerMovement.currentCell].position;
            turnManager.nextTurnPlayer = false;
        }
    }
    private void Inn(PlayerMovement _playerMovement)
    {
        AudioManager.instance.PlaySound(audioClipInnOpen);
        AudioManager.instance.PlaySound(audioClipInnPeople);
        AudioManager.instance.PlaySound(audioClipInnClose);
        _playerMovement.noPlayableTurns++;
    }
    private void Well(PlayerMovement _playerMovement)
    {
        AudioManager.instance.PlaySound(audioClipWell);
        // Sum up 3 no playable turns
        _playerMovement.noPlayableTurns = _playerMovement.noPlayableTurns + 3;
        playerInWellRemainingTurns = 3;

        // Check if there is anyone in the Well
        if (playerInWell != null)
        {
            // Set free whoever was in the well
            playerInWell.noPlayableTurns = 0;
            Debug.Log("the player " + playerInWell.playerID + " has been released thanks to: " + _playerMovement.playerID);
        }

        playerInWell = _playerMovement;
        Debug.Log("the player " + playerInWell.playerID + " is stuck during: " + _playerMovement.noPlayableTurns + " TURNS");

    }
    private void Labyrinth(PlayerMovement _playerMovement, GameObject player)
    {
        AudioManager.instance.PlaySound(audioClipLab);
        _playerMovement.currentCell = 30;
        player.transform.position = CellManager.instance.cells[_playerMovement.currentCell].position;
        Well(_playerMovement);

    }
    private void Jail(PlayerMovement _playerMovement)
    {
        AudioManager.instance.PlaySound(audioClipJail);
        _playerMovement.noPlayableTurns = _playerMovement.noPlayableTurns + 2;
        Debug.Log("¿Entra en la carcel?");
    }
    private void Dices(PlayerMovement _playerMovement, GameObject player)
    {
        gameManagerUI.StartAnimatingDiceRhymes();
        if (_playerMovement.currentCell == firstDice)
        {
            AudioManager.instance.PlaySound(audioClipDice);
            _playerMovement.currentCell = secondDice;
            player.transform.position = CellManager.instance.cells[_playerMovement.currentCell].position;

        }
        else if (_playerMovement.currentCell == secondDice)
        {
            AudioManager.instance.PlaySound(audioClipDice);
            _playerMovement.currentCell = firstDice;
            player.transform.position = CellManager.instance.cells[_playerMovement.currentCell].position;

        }
        turnManager.nextTurnPlayer = false;
    }
    private void Death(PlayerMovement _playerMovement, GameObject player)
    {
        AudioManager.instance.PlaySound(audioClipDeath);
        if (_playerMovement.playerID == "Player 1" || _playerMovement.playerID == "Jugador 1" || _playerMovement.playerID == "- 4")
        {
            _playerMovement.currentCell = 68;
            player.transform.position = CellManager.instance.cells[_playerMovement.currentCell].position;
            _playerMovement.currentCell = 0;
        }
        else if (_playerMovement.playerID == "Player 2" || _playerMovement.playerID == "Jugador 2" || _playerMovement.playerID == "- 4")
        {
            _playerMovement.currentCell = 69;
            player.transform.position = CellManager.instance.cells[_playerMovement.currentCell].position;
            _playerMovement.currentCell = 0;
        }
        else if (_playerMovement.playerID == "Player 3" || _playerMovement.playerID == "Jugador 3" || _playerMovement.playerID == "- 4")
        {
            _playerMovement.currentCell = 70;
            player.transform.position = CellManager.instance.cells[_playerMovement.currentCell].position;
            _playerMovement.currentCell = 0;
        }
        else if (_playerMovement.playerID == "Player 4" || _playerMovement.playerID == "Jugador 4" || _playerMovement.playerID == "- 4")
        {
            _playerMovement.currentCell = 71;
            player.transform.position = CellManager.instance.cells[_playerMovement.currentCell].position;
            _playerMovement.currentCell = 0;
        }
        else
        {
            Debug.Log("no ID");
        }

    }
    private void Final(PlayerMovement _playerMovement)
    {
        gameManager.Win(_playerMovement);
        //meterle el player
    }
    private void Garden(PlayerMovement _playerMovement, GameObject player)
    {
        int difference = 0; //the difference beetween where the player is and the final cell
        Debug.Log("El jugador se mueve a la casilla " + _playerMovement.currentCell);

        difference = (_playerMovement.currentCell - finalCell);

        Debug.Log("El valor necesario para entrar en el Jardín desde la casilla " + _playerMovement.currentCell + " es: " + difference);
        Debug.Log("El jugador se mueve a la casilla " + (finalCell - difference));


        player.transform.position = CellManager.instance.cells[finalCell - difference].position;
        _playerMovement.currentCell = finalCell - difference;

        CheckSpecialCell(_playerMovement, _playerMovement.gameObject);
    }
    private IEnumerator GardenBackwards(PlayerMovement _playerMovement, GameObject player)//corrutina
    {
        int difference = 0; //the difference beetween where the player is and the final cell
        Debug.Log("El jugador se mueve a la casilla " + _playerMovement.currentCell);

        difference = (_playerMovement.currentCell - finalCell);

        Debug.Log("El valor necesario para entrar en el Jardín desde la casilla " + _playerMovement.currentCell + " es: " + difference);
        Debug.Log("El jugador se mueve a la casilla " + (finalCell - difference));

        //ussing the corroutine if for adding a delay
        for (int i = finalCell; i >= finalCell - difference; i--)
        {
            _playerMovement.currentCell = i;
            player.transform.position = CellManager.instance.cells[_playerMovement.currentCell].position;
            yield return new WaitForSeconds(0.05f);
        }

        //por alguna razon aqui se cambia de jugador
        CheckSpecialCell(_playerMovement, _playerMovement.gameObject);
    }
    public void CheckWhosTurn(PlayerMovement player)
    {
        // Check if the actual turn is from the player in the well
        //Debug.Log(">>>>>>> TURN OF  " + player.playerID);
        if(playerInWell != null)
        {
            //Debug.Log("player.playerID: " + player.playerID + "playerInWell.playerID: " + playerInWell.playerID);
            if (player.playerID == playerInWell.playerID)
            {
                //Debug.Log("PLAYER IN WELL " + player.playerID + " HAS " + playerInWellRemainingTurns + "TURNS LEFT IN THE WELL");
                if (playerInWellRemainingTurns > 0)
                {
                    playerInWellRemainingTurns--;
                }
                else
                {
                    //Debug.Log("PLAYER IN WELL " + player.playerID + " DOES NOT HAVE TURNLS LEFT IN THE WELL, TAKE IT OUT");
                    playerInWell = null;
                }
            }
        }
        
    }
}
