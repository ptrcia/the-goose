using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] Color color;
    Light lightScene;
    void Awake()
    {
        lightScene = gameObject.GetComponent<Light>();
    }
    private void Start()
    {
        lightScene.color = color;
    }
}
