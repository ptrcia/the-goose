using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponentToggle : MonoBehaviour
{
    public GameObject componentToToggle;  

  
    public void ToggleComponent(bool isActive)
    {
        if (componentToToggle != null)
        {
            componentToToggle.SetActive(isActive);
        }
    }
}