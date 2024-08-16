using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBackground : MonoBehaviour
{
    RectTransform background;
    public float amplitude;
    private Vector3 initialPosition;
    public bool vertical;
    public bool horizontal;

    void Start()
    {
        background = GetComponent<RectTransform>();
        initialPosition = background.position;
    }

    void Update()
    {
        float yPos = amplitude * Mathf.Sin(Time.time);
        if (vertical && horizontal == false)
        {
            background.position = new Vector3(initialPosition.x, initialPosition.y + yPos, 0);
        }
        else if (horizontal && vertical == false)
        {
            background.position = new Vector3(initialPosition.x + yPos, initialPosition.y, 0);
        }
        else if(vertical && horizontal)
        {
            background.position = new Vector3(initialPosition.x + yPos, initialPosition.y + yPos, 0);
        }
        else
        {
            Debug.Log("No bool checked, is not moving");
        }
        //background.position = new Vector3(initialPosition.x + yPos, initialPosition.y + yPos, 0);
    }
}

