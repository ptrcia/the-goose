using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellContainer : MonoBehaviour
{
    public int currentPlayersInCell;
    public List<string> playersInCell = new List<string>();
    public List<GameObject> playersObjectsInCell = new List<GameObject>();

    PlayerMovement playerMovementCtrl;

    Vector3 centerPos;
    Vector3 up;
    Vector3 down;
    Vector3 upRight;
    Vector3 upleft;
    Vector3 downRight;
    Vector3 downLeft;

    private void OnCollisionEnter(Collision collision)
    {
        //si estas en la lista no te meto en la lista
        playerMovementCtrl = collision.gameObject.GetComponent<PlayerMovement>();

        if (collision.gameObject.CompareTag("Player") && collision.gameObject != null)
        {
            if ( playerMovementCtrl.IsMoovingToLastCell())
            {
                Debug.Log("Entrado");
                currentPlayersInCell++;
                if (!playersObjectsInCell.Contains(collision.gameObject))
                {
                    playersObjectsInCell.Add(collision.gameObject);
                    Debug.Log("Enter List  of the " + currentPlayersInCell + " players in " + gameObject.name + ": " + string.Join(", ", playersInCell));
                    CellArragement();
                    Debug.Log("CUENTOS JUGADORES HAY: " + playersObjectsInCell.Count);
                }
            }
            
        }
        else if (collision.gameObject != null)
        {
            //Debug.Log("Check this in the future");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("THE PLAYER " + (collision.gameObject.GetComponent<PlayerMovement>().playerID).ToString() + " OUT FROM THE CELL");
        if (collision.gameObject.CompareTag("Player") && collision.gameObject != null)
        {
            if (playersObjectsInCell.Contains(collision.gameObject))
            {
                playersObjectsInCell.Remove(collision.gameObject);
                currentPlayersInCell--;
                Debug.Log("Exit List of the " + currentPlayersInCell + " players in " + gameObject.name + ": " + string.Join(", ", playersInCell));


                if (currentPlayersInCell > 0)
                {
                    CellArragement();
                }
                else
                {
                    //Debug.Log("NO MORE PLAYERS TO ARRANGE");
                }
            }
        }
        else if (collision.gameObject == null)
        {
            Debug.Log("Null: collision.gameObject in OnCollisionExit.");
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Nombre de la ficha: " + collision.gameObject.GetComponent<PlayerMovement>().playerID);
        }
    }

    #region Cell Arragement

    private void CellArragement()
    {

        centerPos = new Vector3(
                    gameObject.transform.position.x,
                    gameObject.transform.position.y,
                    gameObject.transform.position.z);
        up = centerPos + new Vector3(0, 0, 0.2f);
        down = centerPos + new Vector3(0, 0, -0.2f);
        upRight = centerPos + new Vector3(-0.17f, 0, 0.2f);
        upleft = centerPos + new Vector3(0.17f, 0, 0.2f);
        downRight = centerPos + new Vector3(0.17f, 0, -0.2f);
        downLeft = centerPos + new Vector3(-0.17f, 0, -0.2f);

        switch (playersObjectsInCell.Count)
        {
            case 2:
                Debug.Log("2 players here");
                //up
                playersObjectsInCell[0].transform.position = up;
                //down
                playersObjectsInCell[1].transform.position = down;
                break;
            case 3:
                Debug.Log("3 players here");
                //down
                playersObjectsInCell[0].transform.position = down;
                //up right
                playersObjectsInCell[1].transform.position = upRight;
                //up left
                playersObjectsInCell[2].transform.position = upleft;
                break;
            case 4:
                Debug.Log("4 players here");
                //down right
                playersObjectsInCell[0].transform.position = downRight;
                //up right
                playersObjectsInCell[1].transform.position = upRight;
                //up left
                playersObjectsInCell[2].transform.position = upleft;
                //down left
                playersObjectsInCell[3].transform.position = downLeft;
                break;
            default:
                Debug.Log("Center");
                playersObjectsInCell[0].transform.position = centerPos;
                break;
        }
    }

    #endregion

}
